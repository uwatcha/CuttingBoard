using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteManager : DontDestroySingleton<NoteManager>
{
    [SerializeField] private Note notePrefab;
    private readonly TimeMatchChecker tmc = new();
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    private readonly List<Vector2> notePositions = new() { new Vector2(4, 7.5f), new Vector2(12, 7.5f), new Vector2(12, 2.5f), new Vector2(4, 2.5f) };
    [SerializeField] private Transform notesDirectory;
    [SerializeField] private double selfDestroyTime = 3;
    private List<Note> generatedNotes = new();
    private List<double> generatedTimes = new();
    private NoteJudgment noteJudgment = new();
    private List<Judgment> results = new();
    [SerializeField] private TextMeshProUGUI touchNotesCountText;
    [SerializeField] private TextMeshProUGUI judgmentText;
    private int startI = 0;
    private int endI = 4;

    void Update()
    {
        for (int i = startI; i < endI; i++)
        {
            if (tmc.IsNowAtTime(i))
            {
                Logger.Log("Now is Generate time", i);
                noteJustTimeTexts[i % 4].Note = GenerateNote(notePositions[i % 4].x, notePositions[i % 4].y, i + 2);
                Logger.Log($"generatedTimes[i] + selfDestroyTime < Timer.GetPlayingTime() -> {generatedTimes[i]} + {selfDestroyTime} < {Timer.GetPlayingTime()} = {generatedTimes[i] + selfDestroyTime < Timer.GetPlayingTime()}");
                if (generatedTimes[i] + selfDestroyTime < Timer.GetPlayingTime())
                {
                    RemoveNote(generatedNotes[0]);
                    startI++;
                    endI++;
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
        Logger.Log($"GenerateNote(): {gameObject.name}");
        Note note = Instantiate(notePrefab, notesDirectory);
        note.Initialize(x, y, justTime, SumJudgments);
        note.gameObject.name = "Note_JustTime: " + justTime;
        generatedNotes.Add(note);
        generatedTimes.Add(Timer.GetPlayingTime());
        return note;
    }

    private void RemoveNote(Note removedNote)
    {
        int index = generatedNotes.IndexOf(removedNote);
        generatedNotes.RemoveAt(index);
        generatedTimes.RemoveAt(index);
        Destroy(removedNote.gameObject);
    }
}
