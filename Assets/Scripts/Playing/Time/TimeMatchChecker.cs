using System;
using UnityEngine;

public class TimeMatchChecker
{
    private bool hasMatched;
    private double matchedTime;
    public TimeMatchChecker()
    {
        hasMatched = false;
        matchedTime = float.MaxValue;
    }

    public bool IsNowAtTime(double targetTime)
    {
        if (!hasMatched && Math.Abs(Timer.GetPlayingTime() - targetTime) < Time.deltaTime * 0.9)
        {
            hasMatched = true;
            matchedTime = Timer.GetPlayingTime();
            return true;
        }
        else if (hasMatched && Timer.GetPlayingTime() - matchedTime >= Time.deltaTime * 1.1)
        {
            hasMatched = false;
            return false;
        }
        else
        {
            return false;
        }
    }
}