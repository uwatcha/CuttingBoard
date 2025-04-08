using System;
using UnityEngine;

public abstract class NoteBase : MonoBehaviour
{
    protected double justTime;
    public double JustTime => justTime;
    protected double selfDestroyTime;
    
    public virtual void Initialize(noteArgs noteArgs)
    {
        justTime = noteArgs.justMilliseconds;
        selfDestroyTime = noteArgs.selfDestroyTime;
        Invoke(nameof(DestroyMyself), (float)selfDestroyTime);
    }

    public void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
