using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NoteManager : DontDestroySingleton<NoteManager>
{
    [SerializeField] private Note notePrefab;
    private readonly TimeMatchChecker tmc = new();
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    private readonly List<Vector2> notePositions = new() { new(4, 7.5f), new(12, 7.5f), new(12, 2.5f), new(4, 2.5f) };
    [SerializeField] private Transform notesDirectory;
    private NoteJudgment noteJudgment = new();
    private List<Judgment> results = new();
    [SerializeField] private TextMeshProUGUI touchNotesCountText;
    [SerializeField] private TextMeshProUGUI judgmentText;
    private int startI = 0;
    private int endI = 4;

    private System.Random rnd = new();
    void Update()
    {
        for (int i = /*startI*/0; i < /*endI*/100; i++)
        {
            if (tmc.IsNowAtTime(i))
            {
                Logger.Log($"Note Generate. (i: {i})");
                float rndX = rnd.Next(-10, 10)/10f;
                float rndY = rnd.Next(-10, 10)/10f;
                noteJustTimeTexts[i % 4].Note = GenerateNote(notePositions[i % 4].x+rndX, notePositions[i % 4].y+rndY, i + 2);
            }
        }
    }

    private void SumJudgments(Note note)
    {
        Judgment? result = noteJudgment.Judge(note);
        if (result != null)
        {
            results.Add(result.Value);
            Destroy(note.gameObject);
            touchNotesCountText.text = $"TouchNotes: {results.Count}";
            judgmentText.text = $"{result.Value}";
        }
    }

    private Note GenerateNote(float x, float y, float justTime)
    {
        Note note = Instantiate(notePrefab, notesDirectory);
        double selfDestroyTime = 3;
        note.Initialize(x, y, justTime, selfDestroyTime, SumJudgments);
        note.gameObject.name = "Note_JustTime: " + justTime;
        return note;
    }
}
