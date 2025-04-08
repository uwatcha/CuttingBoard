using System.Collections.Generic;
using UnityEngine;

public class GroupNotes : MonoBehaviour, INote
{
    [SerializeField] private Note note1;
    [SerializeField] private Note note2;

    private double justTime;
    public double JustTime => justTime;

    public void Initialize(NoteProps noteProps)
    {
        justTime = noteProps.justMilliseconds;
        NoteProps props1 = new(noteProps.justMilliseconds, noteProps.selfDestroyTime, noteProps.coordinates[0]);
        NoteProps props2 = new(noteProps.justMilliseconds, noteProps.selfDestroyTime, noteProps.coordinates[1]);
        note1.Initialize(props1);
        note2.Initialize(props2);
        Invoke(nameof(DestroyMyself), (float)noteProps.selfDestroyTime);
    }

    public void DestroyMyself()
    {
        Destroy(gameObject);
    }
}