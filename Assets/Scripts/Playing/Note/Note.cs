using System;
using UnityEngine;

public class Note : NoteBase
{
    private NoteJudgment noteJudgment = new();
    
    public override void Initialize(noteArgs noteArgs)
    {
        base.Initialize(noteArgs);
        Vector2 coord = noteArgs.coordinates[0];
        transform.position = new(coord.x, coord.y, 0);
    }

    public void OnPointerDown()
    {
        Tuple<Judgment, double> result = noteJudgment.Judge(this);
        DestroyMyself();
        NoteManager.Instance.ApplyJudgmentResult(new(result.Item1, result.Item2));
    }
}
