using System.Collections.Generic;
using UnityEngine;

public class GroupNotes : MonoBehaviour
{
    [SerializeField] private Note note1;
    [SerializeField] private Note note2;
    public void Initialize(float x1, float y1, float x2, float y2, double justMilliseconds, double selfDestroyTime)
    {
        note1.Initialize(x1, y1, justMilliseconds, selfDestroyTime);
        note1.Initialize(x2, y2, justMilliseconds, selfDestroyTime);
    }
}