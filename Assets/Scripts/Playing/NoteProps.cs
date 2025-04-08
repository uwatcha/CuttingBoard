using UnityEngine;

public class NoteProps
{
    public Vector2[] coordinates;
    public double justMilliseconds;
    public double selfDestroyTime;
    public NoteProps (double justMilliseconds, double selfDestroyTime, params Vector2[] coordinates)
    {
        this.coordinates = coordinates;
        this.justMilliseconds = justMilliseconds;
        this.selfDestroyTime = selfDestroyTime;
    }
}