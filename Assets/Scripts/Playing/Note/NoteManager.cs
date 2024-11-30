using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private Note notePrefab;
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    private readonly List<Vector2> notePositions = new(){new Vector2(4, 7.5f), new Vector2(12, 7.5f), new Vector2(12, 2.5f), new Vector2(4, 2.5f)};
    [SerializeField] private Transform notes;
    private readonly TimeMatchChecker tmc = new();

    void Update()
    {
        for (int i=0; i<100; i++)
        {
            if (tmc.IsAtTime(i))
            {
                noteJustTimeTexts[i%4].Note = GenerateNote(notePositions[i%4].x, notePositions[i%4].y, i+1);
            }
        }
    }
    private Note GenerateNote(float x, float y, float justTime)
    {
        Note note = Instantiate(notePrefab, notes);
        note.Initialize(x, y, justTime);
        note.gameObject.name = "Note_JustTime: "+justTime;
        return note;
    }
}
