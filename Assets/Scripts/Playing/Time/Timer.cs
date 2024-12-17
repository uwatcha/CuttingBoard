using System;
using UnityEngine;
public static class Timer
{
    public static void Initialize()
    {
        playStartTime = Time.timeAsDouble;
    }
    private static double playStartTime;
    public static double GetPlayingTime() => Time.timeAsDouble - playStartTime;
}