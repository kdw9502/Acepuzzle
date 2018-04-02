using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class Unity3dBuilder : EditorWindow{

	static string[] SCENES = FindEnabledEditorScenes();
	static string TARGET_DIR = "Build";
	static string ANDROID_APP_ID = "com.com2us.mlbgm.normal.freefull.google.global.android.common";

	static string ANDROID_VERSION = "0.0.0";
	static int ANDROID_BUNDLE_VERSION_CODE = 0; 

	static string IOS_VERSION = "0.0.0";
	static string IOS_BUNDLE_VERSION_CODE = "0";

	static bool android=true;
	static bool device=false;
	static bool simulator=false;
	static Unity3dBuilder builder;

	enum PluginsEnum
	{
		ActiveUser=1,
		Mercury=2,
		InApp=4,
		Push=8
	}
	static PluginsEnum PluginFlag=0;
	[MenuItem ("Build/Build Selected",false,500)]
	public static void  ShowWindow () {
		
		builder=(Unity3dBuilder)EditorWindow.GetWindow(typeof(Unity3dBuilder),true,"Build option");
	}

	void OnGUI(){
		bool _android;
		bool _simulator;
		bool _device;
		GUILayout.Label ("Platform", EditorStyles.boldLabel);
		EditorGUILayout.BeginHorizontal ();
			GUILayout.Label ("android");
			_android=EditorGUILayout.Toggle (android);
			GUILayout.Label ("iOS simulator");
			_simulator=EditorGUILayout.Toggle (simulator);
			GUILayout.Label ("iOS device");
			_device=EditorGUILayout.Toggle (device);
		EditorGUILayout.EndHorizontal ();

		GUILayout.Label ("Plugins", EditorStyles.boldLabel);
		PluginFlag = (PluginsEnum)EditorGUILayout.EnumMaskField ("PlugIns", PluginFlag);
		//exclusive choise
		if(android !=_android || simulator!=_simulator || device!=_device){
		android 	=  _android ^ android;
		simulator 	=  _simulator ^ simulator;
		device		=  _device ^ device;
		}
		bool doBuild = GUILayout.Button ("Build");
		if (doBuild) 
		{
			adjustPluginImport();
			if (android) 
			{
				PerformAndroidBuild ();
			} 
			else if (simulator) 
			{
				PerformiOSSimulatorBuild ();
			} 
			else if (device)
			{
				PerformiOSDeviceBuild ();
			}
			//builder.Close ();
		}
	}
	[MenuItem("Build/adjust")]
	static void adjustPluginImport(){

		List<PluginImporter> simulatorList,deviceList;
		PluginImporter[] imports = PluginImporter.GetAllImporters ();
		simulatorList=new List<PluginImporter>();
		deviceList=new List<PluginImporter>();
		foreach (PluginImporter import in imports) {
			if (import.assetPath.EndsWith ("simulator.a") || import.assetPath.EndsWith ("simulatord.a")) {
				simulatorList.Add (import);
			}
			else if(import.assetPath.EndsWith("iphoneos.a") || import.assetPath.EndsWith("iphoneosd.a") ){
				deviceList.Add (import);
			}
		}

		if (android) {
			foreach (PluginImporter import in simulatorList) {
				import.SetCompatibleWithPlatform ("iOS",false);
			}
			foreach (PluginImporter import in deviceList) {
				import.SetCompatibleWithPlatform ("iOS",false);
			}
		} else if (simulator) {
			foreach (PluginImporter import in simulatorList) {
				import.SetCompatibleWithPlatform ("iOS",true);
			}
			foreach (PluginImporter import in deviceList) {
				import.SetCompatibleWithPlatform ("iOS",false);
			}
		} else if (device) {
			foreach (PluginImporter import in simulatorList) {
				import.SetCompatibleWithPlatform ("iOS",false);
			}
			foreach (PluginImporter import in deviceList) {
				import.SetCompatibleWithPlatform ("iOS",true);

			}
		}
	}
	[MenuItem ("Build/Android")]
	static void PerformAndroidBuild (){
		android = true; device = false; simulator = false;
		adjustPluginImport ();

		EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Internal; 
		BuildOptions opt = BuildOptions.AcceptExternalModificationsToPlayer;

		PlayerSettings.renderingPath = RenderingPath.VertexLit;    

		PlayerSettings.bundleVersion = ANDROID_VERSION;
		PlayerSettings.Android.bundleVersionCode = ANDROID_BUNDLE_VERSION_CODE;

		PlayerSettings.Android.keystoreName = "Build/user.keystore";
		PlayerSettings.Android.keystorePass = "0vmfqhf!";
		PlayerSettings.Android.keyaliasName = "acepuzzle";  
		PlayerSettings.Android.keyaliasPass = "0vmfqhf!";
		//안드로이드는 앱네임을 unity-android-resources에 있는 res/values/strings.xml에서 변경할 수 있다.
		PlayerSettings.companyName="ACEPROEJCT";
		PlayerSettings.productName="9inningsManager";
		PlayerSettings.applicationIdentifier = ANDROID_APP_ID;

		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Android, "DEV_SERVER;DEV_VER;ENABLE_LOG;");

		PlayerSettings.SetUseDefaultGraphicsAPIs( BuildTarget.Android, false );
		PlayerSettings.SetGraphicsAPIs( BuildTarget.Android, new [] { UnityEngine.Rendering.GraphicsDeviceType.OpenGLES2, UnityEngine.Rendering.GraphicsDeviceType.Metal } );

		string BUILD_TARGET_PATH = TARGET_DIR + "/Android";
		Directory.CreateDirectory(BUILD_TARGET_PATH);

		GenericBuild(SCENES, BUILD_TARGET_PATH, BuildTarget.Android , opt);

	}
	[MenuItem ("Build/iOS/Device")]
	static void PerformiOSDeviceBuild (){
		android = false; device = true; simulator = false;
		adjustPluginImport ();

		BuildOptions opt = BuildOptions.AcceptExternalModificationsToPlayer;

		PlayerSettings.renderingPath = RenderingPath.VertexLit;        
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK;

		PlayerSettings.bundleVersion = IOS_VERSION;
		PlayerSettings.iOS.buildNumber = IOS_BUNDLE_VERSION_CODE;

		PlayerSettings.companyName="ACEPROEJCT";
		PlayerSettings.productName = "9InningsManager";        
		PlayerSettings.iPhoneBundleIdentifier = "com.com2us.ent.mlbgm";

		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.iOS, "DEV_SERVER;DEV_VER;ENABLE_LOG;");

		//2018.02.05추가 : Unity5.6으로 업데이트 하면서 발생한 이슈
		PlayerSettings.SetUseDefaultGraphicsAPIs( BuildTarget.iOS, false );
		PlayerSettings.SetGraphicsAPIs( BuildTarget.iOS, new [] { UnityEngine.Rendering.GraphicsDeviceType.OpenGLES2, UnityEngine.Rendering.GraphicsDeviceType.Metal } );

		string BUILD_TARGET_PATH = TARGET_DIR + "/iOS";
		Directory.CreateDirectory(BUILD_TARGET_PATH);

		//2018.03.19추가: AutoSigning 해제
		PlayerSettings.iOS.appleEnableAutomaticSigning=false;

		GenericBuild(SCENES, BUILD_TARGET_PATH, BuildTarget.iOS, opt);


	}
	[MenuItem ("Build/iOS/Simulator")]
	static void PerformiOSSimulatorBuild (){
		android = false; device = false; simulator = true;
		adjustPluginImport ();
		BuildOptions opt = BuildOptions.AcceptExternalModificationsToPlayer;

		PlayerSettings.renderingPath = RenderingPath.VertexLit;        
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.SimulatorSDK;

		PlayerSettings.bundleVersion = IOS_VERSION;
		PlayerSettings.iOS.buildNumber = IOS_BUNDLE_VERSION_CODE;

		PlayerSettings.companyName="ACEPROEJCT";
		PlayerSettings.productName = "9InningsManager";        
		PlayerSettings.iPhoneBundleIdentifier = "com.com2us.ent.mlbgm";

		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.iOS, "DEV_SERVER;DEV_VER;ENABLE_LOG;");

		//2018.02.05추가 : Unity5.6으로 업데이트 하면서 발생한 이슈
		PlayerSettings.SetUseDefaultGraphicsAPIs( BuildTarget.iOS, false );
		PlayerSettings.SetGraphicsAPIs( BuildTarget.iOS, new [] { UnityEngine.Rendering.GraphicsDeviceType.OpenGLES2, UnityEngine.Rendering.GraphicsDeviceType.Metal } );

		string BUILD_TARGET_PATH = TARGET_DIR + "/iOS";
		Directory.CreateDirectory(BUILD_TARGET_PATH);

		//2018.03.19추가: AutoSigning 해제
		PlayerSettings.iOS.appleEnableAutomaticSigning=false;

		GenericBuild(SCENES, BUILD_TARGET_PATH, BuildTarget.iOS, opt);
	}


	private static string[] FindEnabledEditorScenes()
	{
		List<string> EditorScenes = new List<string>();

		foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
		{
			if (!scene.enabled)
			{
				continue;
			}

			EditorScenes.Add(scene.path);
		}

		return EditorScenes.ToArray();
	}
	static void GenericBuild(string[] scenes, string target_filename, BuildTarget build_target, BuildOptions build_options)
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
		string res = BuildPipeline.BuildPlayer(scenes, target_filename, build_target, build_options);
		if (res.Length > 0)
		{
			throw new Exception("BuildPlayer failure: " + res);
		}
	}

}
