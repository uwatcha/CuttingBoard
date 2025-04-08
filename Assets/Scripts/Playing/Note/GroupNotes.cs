using UnityEngine;

public class GroupNotes : Note
{
    [SerializeField] private Note note1;
    [SerializeField] private Note note2;

    public override void Initialize(noteArgs noteArgs)
    {
        base.Initialize(noteArgs);
        noteArgs props1 = new(noteArgs.justMilliseconds, noteArgs.selfDestroyTime, noteArgs.coordinates[0]);
        noteArgs props2 = new(noteArgs.justMilliseconds, noteArgs.selfDestroyTime, noteArgs.coordinates[1]);
        note1.Initialize(props1);
        note2.Initialize(props2);
    }
}