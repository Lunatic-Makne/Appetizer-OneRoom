using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;
using Codice.Client.BaseCommands;

// Output the build size or a failure depending on BuildPlayer.

public class BuildPlayer : MonoBehaviour
{
    //[MenuItem("Build/Build AOS")]
    //public static void MyBuild_AOS()
    //{
    //    BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
    //    buildPlayerOptions.scenes = new[] { "Assets/Scene1.unity", "Assets/Scene2.unity" };
    //    buildPlayerOptions.locationPathName = $"Builds/AOS_{PlayerSettings.bundleVersion}.apk";
    //    buildPlayerOptions.target = BuildTarget.Android;
    //    buildPlayerOptions.options = BuildOptions.None;

    //    BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
    //    BuildSummary summary = report.summary;

    //    if (summary.result == BuildResult.Succeeded)
    //    {
    //        Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
    //    }

    //    if (summary.result == BuildResult.Failed)
    //    {
    //        Debug.Log("Build failed");
    //    }
    //}

    [MenuItem("Build/Build")]
    public static void MyBuild_Windows()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/StartUp.unity", "Assets/Game.unity" };
        buildPlayerOptions.locationPathName = $"../../../Builds/Windows/OneRoom.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;

        var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        var summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build successed: " + summary.totalSize + " bytes");
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed: " + summary.totalErrors + " errors / " + summary.totalWarnings + " warnings");
        }
    }
}