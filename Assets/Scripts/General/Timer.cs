using UnityEngine;
public static class Timer
{
    public static void Initialize()
    {
        playStartTime = Time.time;
    }
    private static float playStartTime;
    public static float GetPlayingTime() => Time.time - playStartTime;
}