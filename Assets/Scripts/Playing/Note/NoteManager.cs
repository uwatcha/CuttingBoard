using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : DontDestroySingleton<NoteManager>
{
    [SerializeField] private Note notePrefab;
    private readonly TimeMatchChecker tmc = new();
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    private readonly List<Vector2> notePositions = new() { new Vector2(4, 7.5f), new Vector2(12, 7.5f), new Vector2(12, 2.5f), new Vector2(4, 2.5f) };
    [SerializeField] private Transform notesDirectory;
    private Queue<Note> generatedNotes = new();
    private NoteJudgment noteJudgment = new();
    private List<Judgment> results = new();

    void Update()
    {
        for (int i = 0; i < 100; i++)
        {
            if (tmc.IsNowAtTime(i))
            {
                noteJustTimeTexts[i % 4].Note = GenerateNote(notePositions[i % 4].x, notePositions[i % 4].y, i + 1);
                if (i >= 2)
                {
                    Destroy(generatedNotes.Dequeue().gameObject);
                }
            }
        }
    }

    private void SummarizeJudgments(Note note)
    {
        Judgment? result = noteJudgment.Judge(note);
        if (result != null)
        {
            results.Add(result.Value);
            Destroy(note.gameObject);
        }
    }
    private Note GenerateNote(float x, float y, float justTime)
    {
        Note note = Instantiate(notePrefab, notesDirectory);
        note.Initialize(x, y, justTime, SummarizeJudgments);
        note.gameObject.name = "Note_JustTime: " + justTime;
        generatedNotes.Enqueue(note);
        return note;
    }
}
