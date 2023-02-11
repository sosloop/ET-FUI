using System.IO;
using UnityEditor;
using UnityEngine;

// [InitializeOnLoad]
// public class Keystore
// {
//     // Start is called before the first frame update
//     static Keystore()
//     {
//         var absRoot = Application.dataPath.Replace("/Assets", "");

//         string combine = IPath.Combine(absRoot, "BDTemp/sign.jks");

//         PlayerSettings.Android.keystoreName = combine;

//         // 密钥密码
//         PlayerSettings.Android.keystorePass = "111";

//         // 密钥别名
//         PlayerSettings.Android.keyaliasName = "111";

//         // 密码
//         PlayerSettings.Android.keyaliasPass = "111";


//     }
// }

namespace System.IO
{
    static public class IPath
    {
        //这里是修复Mamc下的 Path.Combine的Bug
        static public string Combine(string a, string b)
        {
            return a + "/" + b;
        }
    }
}