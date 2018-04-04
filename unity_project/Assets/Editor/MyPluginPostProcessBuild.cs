using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using UnityEditor.iOS.Xcode;
using System.IO;
using System.Collections.Generic;

public class MyPluginPostProcessBuild
{
	[PostProcessBuild]
	public static void OnPostProcessBuild( BuildTarget buildTarget, string path)
	{
		if(buildTarget == BuildTarget.iOS)
		{
			string projectPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";

			PBXProject pbxProject = new PBXProject();
			pbxProject.ReadFromFile(projectPath);

			string target = pbxProject.TargetGuidByName("Unity-iPhone");            
			pbxProject.SetBuildProperty(target, "ENABLE_BITCODE", "NO");

			pbxProject.WriteToFile (projectPath);
		}
	}
}