using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteManager : DontDestroySingleton<NoteManager>
{
    //TODO: カメラが寄っている問題を治す
    [SerializeField] private Note notePrefab;
    [SerializeField] private GroupNotes groupNotesPrefab;
    private readonly TimeMatchChecker tmc = new();
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    private readonly List<Vector2> dev_notePositions = new() { new(4, 7.5f), new(12, 7.5f), new(12, 2.5f), new(4, 2.5f) };
    [SerializeField] private Transform notesDirectory;
    //doubleの要素はジャストタイミングからズレた秒数
    private List<Tuple<Judgment, double>> results = new();
    [SerializeField] private TextMeshProUGUI touchedNotesCountText;
    [SerializeField] private TextMeshProUGUI judgmentText;
    [SerializeField] private TextMeshProUGUI timingDiffText;
    private System.Random dev_rnd = new();
    //たまに左下のノーツが押しても反応しない気がするなんでやろ
    void Update()
    {
        // Dev_GenerateNotes();
        Dev_GenerateGroupNotes();
    }
    private void Dev_GenerateNotes()
    {
        for (int i = 0; i < 100; i++)
        {
            if (tmc.IsNowAtTime(i))
            {
                // 開発用に表示位置をずらしている。開発時は適当に位置がばらけた方が画面に変化が表れて嬉しい。
                float rndX = dev_rnd.Next(-5, 5)/10f;
                float rndY = dev_rnd.Next(-5, 5)/10f;
                noteJustTimeTexts[i % 4].Note = GenerateNote(new(dev_notePositions[i % 4].x+rndX, dev_notePositions[i % 4].y+rndY), i + 2);

            }
        }
    }
        private void Dev_GenerateGroupNotes()
    {
        for (int i = 0; i < 100; i++)
        {
            if (tmc.IsNowAtTime(i))
            {
                noteJustTimeTexts[i % 4].Note = GenerateGroupNotes(new(dev_notePositions[i % 4].x, dev_notePositions[i % 4].y - 1), new(dev_notePositions[i % 4].x, dev_notePositions[i % 4].y + 1), i + 2);
            }
        }
    }

    public void ApplyJudgmentResult(Tuple<Judgment, double> result)
    {
        results.Add(result);
        touchedNotesCountText.text = $"TouchedNotesCount: {results.Count}";
        judgmentText.text = $"{result.Item1}";
        timingDiffText.text = $"{result.Item2:F2}(s)";
    }

    private Note GenerateNote(Vector2 coord, float justTime)
    {
        Note note = Instantiate(notePrefab, notesDirectory);
        double selfDestroyTime = 3;
        note.Initialize(new(justTime, selfDestroyTime, coord));
        note.gameObject.name = $"Note_JustTime: {justTime}";
        return note;
    }

    private GroupNotes GenerateGroupNotes(Vector2 coord1, Vector2 coord2, float justTime)
    {
        GroupNotes groupNotes = Instantiate(groupNotesPrefab, notesDirectory);
        double selfDestroyTime = 3;
        groupNotes.Initialize(new(justTime, selfDestroyTime, coord1, coord2));
        groupNotes.gameObject.name = $"GroupNotes_JustTime: {justTime}";
        return groupNotes;
    }
}
