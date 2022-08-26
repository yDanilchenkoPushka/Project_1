﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_GAMECORE
[InitializeOnLoad]
public class SetTitleAndSCID : EditorWindow
{
    [MenuItem("GameCoreSamples/Set Users TitleID and SCID")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SetTitleAndSCID));
    }

    [InitializeOnLoadMethod]
    public static void Initialize()
    {
#if UNITY_GAMECORE_XBOXONE
        Settings = UnityEditor.GameCore.GameCoreXboxOneSettings.GetInstance();
#endif
#if UNITY_GAMECORE_SCARLETT
        Settings = UnityEditor.GameCore.GameCoreScarlettSettings.GetInstance();
#endif

        if (
            Settings.GameConfig.TitleId == null || Settings.GameConfig.TitleId.Length == 0
            || Settings.GameConfig.MSAAppId == null || Settings.GameConfig.MSAAppId.Length == 0
            || Settings.SCID == null || Settings.SCID.Length == 0
            )
        UnityEditor.EditorApplication.delayCall += () =>
        {
            ShowWindow();
        };
    }

    void OnGUI()
    {
        string TestSandbox = "UTDK.1";
        string TestTitleID = "1A81FB73";
        string TestSCID = "dd5d0100-6626-4bb3-a6a9-81991a81fb73";
        string TestMSAAppID = "000000004C26A711";
        GUILayout.Space(10);
        GUILayout.Label("Game Core Package Users Sample - Requirements");
        GUILayout.Space(10);
        GUILayout.Label("Make sure you set the Title ID, SCID, MSA App ID to valid values");
        GUILayout.Label("in Player Settings -> Publishing Settings and run on your own");
        GUILayout.Label("sandbox.");
        GUILayout.Space(30);
        GUILayout.Label("If you do not have your own, you can use these values as a test:");
        GUILayout.Space(1);
        GUILayout.Label("Title ID:");
        GUILayout.TextArea(TestTitleID);
        GUILayout.Label("SCID:");
        GUILayout.TextArea(TestSCID);
        GUILayout.Label("MSA App ID:");
        GUILayout.TextArea(TestMSAAppID);
        GUILayout.Space(10);
        GUILayout.Label("And set the devkit sandbox to:");
        GUILayout.TextArea(TestSandbox);
        if (GUILayout.Button("Apply Values"))
        {
            Settings.GameConfig.TitleId = TestTitleID;
            Settings.GameConfig.MSAAppId = TestMSAAppID;
            Settings.SCID = TestSCID;

            Settings.ApplyAnyChanges();
        }
    }

#if UNITY_GAMECORE_XBOXONE
    static private UnityEditor.GameCore.GameCoreXboxOneSettings Settings;
#endif
#if UNITY_GAMECORE_SCARLETT
    static private UnityEditor.GameCore.GameCoreScarlettSettings Settings;
#endif

#endif // UNITY_GAMECORE
}
