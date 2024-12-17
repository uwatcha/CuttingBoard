using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteJudgment
{
    //これらのスパンは、例えばGREAT_SPANは、PERFECT_SPANとGOOD_SPANの間の時間を表す
    private readonly List<KeyValuePair<Judgment, double>> judgmentSpans = new()
    {
        new(Judgment.Perfect, 3),
        new(Judgment.Great, 3),
        new(Judgment.Good, 3),
        new(Judgment.Bad, 3),
        new(Judgment.Miss, 3)
    };
    Queue<List<Note>> generatedNotes;
    public NoteJudgment(Queue<List<Note>> generatedNotes)
    {
        this.generatedNotes = generatedNotes;
    }
    public Judgment? Judge(Note note)
    {
        if (generatedNotes.Peek().Contains(note))
        {
            double touchDiff = Timer.GetPlayingTime() - note.JustTime;
            double spanMilliseconds = 0;
            foreach(KeyValuePair<Judgment, double> e in judgmentSpans)
            {
                spanMilliseconds += e.Value;
                if (touchDiff < spanMilliseconds)
                {
                    if (generatedNotes.Count >= 2)
                    {
                        generatedNotes.Peek().Remove(note);
                    }
                    else
                    {
                        generatedNotes.Dequeue();
                    }
                    Logger.Log($"Judged Note: {note.gameObject.name}");
                    Logger.Log($"Judgment: {e.Key}");
                    return e.Key;
                }
            }
        }
        return null;
    }
}