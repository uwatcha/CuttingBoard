using System;
using UnityEngine;

public class TimeMatchChecker
{
    private bool hasMatched;
    private float matchedTime;
    public TimeMatchChecker()
    {
        hasMatched = false;
        matchedTime = float.MaxValue;
    }

    public bool IsNowAtTime(float targetTime)
    {
        if (!hasMatched && Math.Abs(Timer.GetPlayingTime() - targetTime) < Time.deltaTime * 0.9)
        {
            Logger.Log("flag set");
            hasMatched = true;
            matchedTime = Timer.GetPlayingTime();
            return true;
        }
        else if (hasMatched && Timer.GetPlayingTime() - matchedTime >= Time.deltaTime * 1.1)
        {
            Logger.Log("flag reset");
            hasMatched = false;
            return false;
        }
        else
        {
            return false;
        }
    }
}