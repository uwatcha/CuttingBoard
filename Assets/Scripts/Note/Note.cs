using UnityEngine;

public class Note : MonoBehaviour
{
    private const float autoDestroyTime = 6;
    private float generatedTime;
    private float justTime;
    public float JustTime => justTime;
    public void Initialize(float x, float y, float justTime)
    {
        transform.position = new Vector3 (x, y, 0);
        generatedTime = Timer.GetPlayingTime();
        this.justTime = justTime;
    }

    void Update()
    {
        if (Timer.GetPlayingTime() >= generatedTime+autoDestroyTime)
        {
            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
