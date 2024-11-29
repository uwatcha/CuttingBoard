using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float playStartTime;
    void Start()
    {
        playStartTime = Time.time;
    }

    void Update()
    {

    }
    public float GetPlayingTime() => Time.time - playStartTime;
}
