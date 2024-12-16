using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private Note notePrefab;
    private readonly TimeMatchChecker tmc = new();
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    private readonly List<Vector2> notePositions = new() { new Vector2(4, 7.5f), new Vector2(12, 7.5f), new Vector2(12, 2.5f), new Vector2(4, 2.5f) };
    [SerializeField] private Transform notesDirectory;
    private Queue<List<Note>> generatedNotes = new();//複数で1つのNoteが今後できれば、キューの１要素に複数のNoteを入れる
    private Action generatedNoteAction;



    void Update()
    {
        for (int i = 0; i < 100; i++)
        {
            if (tmc.IsNowAtTime(i))
            {
                noteJustTimeTexts[i % 4].Note = GenerateNote(notePositions[i % 4].x, notePositions[i % 4].y, i + 1);
                if (i >= 2)
                {
                    generatedNotes.Dequeue().ForEach((note) =>
                    {
                        Logger.Log($"note: {note.gameObject.name}"); generatedNoteAction -= note.OnMouseDown;
                    });
                }
            }
        }
    }
    private Note GenerateNote(float x, float y, float justTime)
    {
        Note note = Instantiate(notePrefab, notesDirectory);
        note.Initialize(x, y, justTime);
        note.gameObject.name = "Note_JustTime: " + justTime;
        generatedNotes.Enqueue(new() { note });
        generatedNoteAction += note.OnMouseDown;
        return note;
    }
}
