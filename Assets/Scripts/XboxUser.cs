using System;
using Unity.GameCore;
using UnityEngine;

public class XboxUser
{
    public event Action<UserData> OnUserUpdated;

    public enum UserOpResult
    {
        Success,
        NoDefaultUser,
        ResolveUserIssueRequired,

        UnknownError
    }

    private enum State
    {
        GetContext,
        WaitForAddingUser,
        GetBasicInfo,
        UserDisplayImage,
        WaitForNextTask,
        Error,
        Idle,
    }

    public struct UserData
    {
        public XUserHandle userHandle;
        public XUserLocalId m_localId;
        public string userGamertag;
        public byte[] imageBuffer;
        public XblContextHandle m_context;
    }

    public delegate void AddUserCompletedDelegate(UserOpResult result);

    private State m_State = State.Idle;
    private UserData m_CurrentUserData;
    private AddUserCompletedDelegate m_CurrentCompletionDelegate;

    public void AddDefaultUser()
    {
        AddDefaultUserSilently(AddUserCompleted);
    }

    public void Tick()
    {
        switch (m_State)
        {
            case State.GetContext:
                GetUserContext();
                break;
            case State.GetBasicInfo:
                GetBasicInfo();
                break;
            case State.UserDisplayImage:
                m_State = State.WaitForNextTask;
                GetUserImage();
                break;
            default:
                break;
        }
    }

    private void AddDefaultUserSilently(AddUserCompletedDelegate completionDelegate)
    {
        Debug.Log("1");
        
        if (m_State != State.Idle)
        {
            // busy adding a user already
            return;
        }
        
        Debug.Log("2");
        
        m_State = State.WaitForAddingUser;
        m_CurrentUserData = new UserData();
        m_CurrentCompletionDelegate = completionDelegate;
        SDK.XUserAddAsync(XUserAddOptions.AddDefaultUserSilently, (Int32 hresult, XUserHandle userHandle) =>
        {
            Debug.Log("2_1");
            
            if (hresult == 0 && userHandle != null)
            {
                Debug.Log("2_2");
                UserOpResult result = GetUserId(userHandle);

                if (result == UserOpResult.Success)
                {
                    Debug.Log("2_3");
                    m_State = State.GetContext;
                }
                else
                {
                    Debug.Log("2_4");
                    m_State = State.Idle;
                    m_CurrentCompletionDelegate(result);
                }
            }
            else if (hresult == HR.E_GAMEUSER_NO_DEFAULT_USER)
            {
                Debug.Log("2_5");
                m_State = State.Idle;
                m_CurrentCompletionDelegate(UserOpResult.NoDefaultUser);
            }
            else
            {
                Debug.Log("2_6");
                m_State = State.Idle;
                m_CurrentCompletionDelegate(UserOpResult.UnknownError);
            }
            
            Debug.Log("3");

        });
    }

    private UserOpResult GetUserId(XUserHandle userHandle)
    {
        Debug.Log("4");

        ulong xuid;
        int hr = SDK.XUserGetId(userHandle, out xuid);
        if (hr == 0)
        {
            m_CurrentUserData.userHandle = userHandle;
            Debug.Log("5");

            return UserOpResult.Success;
        }
        else if (hr == HR.E_GAMEUSER_RESOLVE_USER_ISSUE_REQUIRED)
        {
            Debug.Log("6");

            return UserOpResult.ResolveUserIssueRequired;
        }

        Debug.Log("7");

        return UserOpResult.UnknownError;
    }

    private void GetUserContext()
    {
        Debug.Log("8");

        
        int hr = SDK.XBL.XblContextCreateHandle(m_CurrentUserData.userHandle, out m_CurrentUserData.m_context);
        if (hr == 0 && m_CurrentUserData.m_context != null)
        {
            Debug.Log("9");

            Debug.Log("Success XBL and Context");
            m_State = State.GetBasicInfo;
        }
        else
        {
            Debug.Log("10");

            Debug.Log("Error creating context");
            m_State = State.Error;
        }
    }

    private void GetBasicInfo()
    {
        Debug.Log("11");

        Debug.Log("Grabbing Gamertag and checking if user is a guest");
        int hr = SDK.XUserGetGamertag(m_CurrentUserData.userHandle, XUserGamertagComponent.Classic, 
            out m_CurrentUserData.userGamertag);

        if (hr == 0)
        {      
            Debug.Log("12");

            m_State = State.UserDisplayImage;
        }
        else
        {     
            Debug.Log("13");

            Debug.Log("Failed to grab gamertag and guest status, hresult: " + hr);
            m_State = State.Error;
        }
    }

    private void GetUserImage()
    {
        Debug.Log("14");

        SDK.XUserGetGamerPictureAsync(m_CurrentUserData.userHandle, XUserGamerPictureSize.Large, 
            (Int32 hresult, Byte[] buffer) =>
        {
            if (hresult == 0)
            {
                Debug.Log("15");

                m_CurrentUserData.imageBuffer = buffer;
                m_State = State.Idle;
                UpdateUser();
            }
            else
            {
                Debug.Log("16");

                Debug.Log("Failed to grab image, hresult: " + hresult);
                m_State = State.Error;
            }
        });
    }

    private void AddUserCompleted(UserOpResult result)
    {
        Debug.Log("17");

        
        if (result == UserOpResult.Success)
            UpdateUser();
    }

    private void UpdateUser() => 
        OnUserUpdated?.Invoke(m_CurrentUserData);
}