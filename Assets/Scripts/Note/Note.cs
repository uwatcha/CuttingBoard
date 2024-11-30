using UnityEngine;

public class Note : MonoBehaviour
{
    private const float autoDestroyTime = 6;
    private TimeManager timeManager;
    private float generatedTime;
    private float justTime;
    public float JustTime => justTime;
    public void Initialize(float x, float y, float justTime, TimeManager timeManager)
    {
        transform.position = new Vector3 (x, y, 0);
        this.timeManager = timeManager;
        generatedTime = timeManager.GetPlayingTime();
        this.justTime = justTime;
    }

    void Update()
    {
        if (timeManager.GetPlayingTime() >= generatedTime+autoDestroyTime)
        {
            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
