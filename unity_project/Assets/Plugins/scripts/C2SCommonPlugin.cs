using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class C2SCommonPluginInterface {

#if UNITY_IPHONE
	[DllImport ("__Internal")]
	public static extern void CS_SetModuleView();
#endif
}
