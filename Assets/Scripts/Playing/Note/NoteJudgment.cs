using System;
using System.Collections.Generic;

public class NoteJudgment
{
    //これらのスパンは、例えばGREAT_SPANは、PERFECT_SPANとGOOD_SPANの間の時間を表す
    //TODO: Inspectorから設定できるようにする
    private readonly List<KeyValuePair<Judgment, double>> judgmentSpans = new()
    {
        new(Judgment.Perfect, 0.1),
        new(Judgment.Great, 0.1),
        new(Judgment.Good, 0.1),
        new(Judgment.Bad, 0.1),
        new(Judgment.Miss, 0.1)
    };

    public Judgment? Judge(Note note)
    {
        double touchDiff = Timer.GetPlayingTime() - note.JustTime;
        double spanMilliseconds = 0;
        foreach (KeyValuePair<Judgment, double> e in judgmentSpans)
        {
            spanMilliseconds += e.Value;
            if (Math.Abs(touchDiff) < spanMilliseconds)
            {
                return e.Key;
            }
        }
        return null;
    }
}