//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""47f1f1f8-be89-4d6b-8119-d1b9933e0117"",
            ""actions"": [
                {
                    ""name"": ""Movement_hor"",
                    ""type"": ""Button"",
                    ""id"": ""9b852a90-f6c1-4b3c-a04c-e0fa00922f1f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement_ver"",
                    ""type"": ""Button"",
                    ""id"": ""14768112-542b-4a0f-ab64-5b449f720c38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""38839c40-b80d-46f5-aecf-9a2d8823f69b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_hor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1b4c528e-8f4e-4dc1-b33f-f81eacac8aff"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_hor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ef8a99a9-c726-4b41-ab75-407a52b912fe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_hor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""399d9a9a-a3e2-49f2-89bf-1329a1edc331"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_hor"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""42546a02-193a-4e0c-8e5b-0cd673a95fad"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_hor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""54d55242-45b7-4ca1-ba9c-f32e1e124a81"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_hor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""e8e460be-9d4f-4d0d-9d94-49fd2afb381c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_ver"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d7529600-3b1c-4706-aaa8-556dd174716d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_ver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8c645c5f-f432-410e-abee-0ba1c644e3e3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_ver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""4ab82d12-fb52-40e2-af6a-3ac441a60b81"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_ver"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2c22416c-8f56-4355-a7f2-5eac382a93e4"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_ver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e18e4f07-ca12-4a19-a84e-ecb9a497066b"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_ver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""LevelMenu"",
            ""id"": ""71eb166e-6c98-482d-ae99-37283ce6dbd3"",
            ""actions"": [
                {
                    ""name"": ""Play"",
                    ""type"": ""Button"",
                    ""id"": ""e5e214e5-7cdc-417a-9231-71d761f5a0e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""42b5c754-4ee6-4ba9-8699-d01a03e0d85f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Play"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9b24157-f3ff-4704-b4dd-029a7832e746"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Play"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""0a22b030-e84f-409d-974d-8e434c92fd50"",
            ""actions"": [
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""0172ce78-efa6-47ac-b1ca-b89675b19dec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""a85162a5-d5ab-4dc9-ab77-9a4a9324ee4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""efe63f3b-1841-4f09-92bb-e003589dd1ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8a7b9875-c4ce-4d67-a3fd-df7186e54739"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57532c21-abe6-42ff-84dc-30ea4778c2c6"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c0d2f94-02ad-44f2-8290-372251c3c525"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cf7e093-497c-435d-a197-d943745c73d2"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f981d75-b05f-4b19-ad41-66d16ce313cf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cb5089b-d032-4b49-9c13-11cb988ebccb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement_hor = m_Player.FindAction("Movement_hor", throwIfNotFound: true);
        m_Player_Movement_ver = m_Player.FindAction("Movement_ver", throwIfNotFound: true);
        // LevelMenu
        m_LevelMenu = asset.FindActionMap("LevelMenu", throwIfNotFound: true);
        m_LevelMenu_Play = m_LevelMenu.FindAction("Play", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Down = m_MainMenu.FindAction("Down", throwIfNotFound: true);
        m_MainMenu_Up = m_MainMenu.FindAction("Up", throwIfNotFound: true);
        m_MainMenu_Click = m_MainMenu.FindAction("Click", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement_hor;
    private readonly InputAction m_Player_Movement_ver;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement_hor => m_Wrapper.m_Player_Movement_hor;
        public InputAction @Movement_ver => m_Wrapper.m_Player_Movement_ver;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement_hor.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement_hor;
                @Movement_hor.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement_hor;
                @Movement_hor.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement_hor;
                @Movement_ver.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement_ver;
                @Movement_ver.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement_ver;
                @Movement_ver.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement_ver;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement_hor.started += instance.OnMovement_hor;
                @Movement_hor.performed += instance.OnMovement_hor;
                @Movement_hor.canceled += instance.OnMovement_hor;
                @Movement_ver.started += instance.OnMovement_ver;
                @Movement_ver.performed += instance.OnMovement_ver;
                @Movement_ver.canceled += instance.OnMovement_ver;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // LevelMenu
    private readonly InputActionMap m_LevelMenu;
    private ILevelMenuActions m_LevelMenuActionsCallbackInterface;
    private readonly InputAction m_LevelMenu_Play;
    public struct LevelMenuActions
    {
        private @Controls m_Wrapper;
        public LevelMenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Play => m_Wrapper.m_LevelMenu_Play;
        public InputActionMap Get() { return m_Wrapper.m_LevelMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LevelMenuActions set) { return set.Get(); }
        public void SetCallbacks(ILevelMenuActions instance)
        {
            if (m_Wrapper.m_LevelMenuActionsCallbackInterface != null)
            {
                @Play.started -= m_Wrapper.m_LevelMenuActionsCallbackInterface.OnPlay;
                @Play.performed -= m_Wrapper.m_LevelMenuActionsCallbackInterface.OnPlay;
                @Play.canceled -= m_Wrapper.m_LevelMenuActionsCallbackInterface.OnPlay;
            }
            m_Wrapper.m_LevelMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Play.started += instance.OnPlay;
                @Play.performed += instance.OnPlay;
                @Play.canceled += instance.OnPlay;
            }
        }
    }
    public LevelMenuActions @LevelMenu => new LevelMenuActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Down;
    private readonly InputAction m_MainMenu_Up;
    private readonly InputAction m_MainMenu_Click;
    public struct MainMenuActions
    {
        private @Controls m_Wrapper;
        public MainMenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Down => m_Wrapper.m_MainMenu_Down;
        public InputAction @Up => m_Wrapper.m_MainMenu_Up;
        public InputAction @Click => m_Wrapper.m_MainMenu_Click;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Down.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUp;
                @Click.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    public interface IPlayerActions
    {
        void OnMovement_hor(InputAction.CallbackContext context);
        void OnMovement_ver(InputAction.CallbackContext context);
    }
    public interface ILevelMenuActions
    {
        void OnPlay(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}
