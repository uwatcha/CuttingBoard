using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NoteManager : DontDestroySingleton<NoteManager>
{
    [SerializeField] private Note notePrefab;
    private readonly TimeMatchChecker tmc = new();
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    private readonly List<Vector2> notePositions = new() { new Vector2(4, 7.5f), new Vector2(12, 7.5f), new Vector2(12, 2.5f), new Vector2(4, 2.5f) };
    [SerializeField] private Transform notesDirectory;
    private List<Note> generatedNotes = new();
    private NoteJudgment noteJudgment = new();
    private List<Judgment> results = new();
    [SerializeField] private TextMeshProUGUI touchNotesCountText;
    [SerializeField] private TextMeshProUGUI judgmentText;

    void Update()
    {
        for (int i = 0; i < 100; i++)
        {
            if (tmc.IsNowAtTime(i))
            {
                noteJustTimeTexts[i % 4].Note = GenerateNote(notePositions[i % 4].x, notePositions[i % 4].y, i + 2);
                if (i >= 3)
                {
                    RemoveNote(generatedNotes.Last());
                }
            }
        }
    }

    private void SumJudgments(Note note)
    {
        Judgment? result = noteJudgment.Judge(note);
        if (result != null)
        {
            results.Add(result.Value);
            RemoveNote(note);
            touchNotesCountText.text = $"TouchNotes: {results.Count}";
            judgmentText.text = $"{result.Value}";
        }
    }
    
    private Note GenerateNote(float x, float y, float justTime)
    {
        Note note = Instantiate(notePrefab, notesDirectory);
        note.Initialize(x, y, justTime, SumJudgments);
        note.gameObject.name = "Note_JustTime: " + justTime;
        generatedNotes.Insert(0, note);
        return note;
    }

    private void RemoveNote(Note removedNote)
    {
        generatedNotes.Remove(removedNote);
        Destroy(removedNote.gameObject);
    }
}
