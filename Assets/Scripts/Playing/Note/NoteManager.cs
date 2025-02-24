using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NoteManager : DontDestroySingleton<NoteManager>
{
    //TODO: カメラが寄っている問題を治す
    [SerializeField] private Note notePrefab;
    private readonly TimeMatchChecker tmc = new();
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    private readonly List<Vector2> notePositions = new() { new(4, 7.5f), new(12, 7.5f), new(12, 2.5f), new(4, 2.5f) };
    [SerializeField] private Transform notesDirectory;
    private List<Tuple<Judgment, double>> results = new();
    [SerializeField] private TextMeshProUGUI touchedNotesCountText;
    [SerializeField] private TextMeshProUGUI judgmentText;
    [SerializeField] private TextMeshProUGUI timingDiffText;
    //TODO: ここ実装
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
                float rndX = rnd.Next(-5, 5)/10f;
                float rndY = rnd.Next(-5, 5)/10f;
                noteJustTimeTexts[i % 4].Note = GenerateNote(notePositions[i % 4].x+rndX, notePositions[i % 4].y+rndY, i + 2);
            }
        }
    }

    private void ApplyJudgmentResult(Tuple<Judgment, double> result)
    {
        results.Add(result);
        touchedNotesCountText.text = $"TouchedNotesCount: {results.Count}";
        judgmentText.text = $"{result.Item1}";
        timingDiffText.text = $"{result.Item2:F2}(s)";
    }

    private Note GenerateNote(float x, float y, float justTime)
    {
        Note note = Instantiate(notePrefab, notesDirectory);
        double selfDestroyTime = 3;
        note.Initialize(x, y, justTime, selfDestroyTime, ApplyJudgmentResult);
        note.gameObject.name = "Note_JustTime: " + justTime;
        return note;
    }
}
