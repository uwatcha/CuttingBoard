using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private Note notePrefab;
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    [SerializeField] private Transform notes;
    private TimeMatchChecker tmc = new TimeMatchChecker();
    private System.Random rand = new System.Random();

    void Update()
    {
        // tmc.IsAtTime(1);
        // tmc.IsAtTime(5);
        // tmc.IsAtTime(10);
        // tmc.IsAtTime(15);
        for (float i=1; i<100; i+=0.1f)
        {
            if (tmc.IsAtTime(i))
            {
                GenerateNote((float)(rand.NextDouble() * (12 - 4) + 4), (float)(rand.NextDouble() * (7.5 - 2.5) + 2.5), i+1);
            }
        }
        // if (tmc.IsAtTime(1))
        // {
        //     noteJustTimeTexts[0].Note = GenerateNote(4, 7.5f, 2);
        // }
        // else if (tmc.IsAtTime(3))
        // {
        //     noteJustTimeTexts[1].Note = GenerateNote(12, 7.5f, 4);
        // }
        // else if (tmc.IsAtTime(5))
        // {
        //     noteJustTimeTexts[1].Note = GenerateNote(12, 7.5f, 6);
        // }
        // else if (tmc.IsAtTime(7))
        // {
        //     noteJustTimeTexts[1].Note = GenerateNote(12, 7.5f, 8);
        // }
    }
    private Note GenerateNote(float x, float y, float justTime)
    {
        Note note = Instantiate(notePrefab, notes);
        note.Initialize(x, y, justTime);
        note.gameObject.name = ""+justTime;
        return note;
    }
}
