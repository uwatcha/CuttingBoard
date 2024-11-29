//参考コード：https://github.com/CreativeAI2024/CreativeAI2024/blob/develop/Assets/Scripts/DebugLogger.cs
//上記の開発者：https://github.com/kanata0510

using System.Diagnostics;
public static class Logger
{
    [Conditional("UNITY_EDITOR")]
    public static void Log(this object o)
    {
        UnityEngine.Debug.Log(o);
    }
    
    [Conditional("UNITY_EDITOR")]
    public static void Log(string tabMessage)
    {
        UnityEngine.Debug.Log(tabMessage);
    }
}