using System;
using UnityEngine;

public class Note : MonoBehaviour, INote
{
    private double justTime;
    public double JustTime => justTime;
    private double selfDestroyTime;
    private NoteJudgment noteJudgment = new();
    
    public void Initialize(NoteProps noteProps)
    {
        Vector2 coord = noteProps.coordinates[0];
        transform.position = new(coord.x, coord.y, 0);
        this.justTime = noteProps.justMilliseconds;
        this.selfDestroyTime = noteProps.selfDestroyTime;
        Invoke(nameof(DestroyMyself), (float)selfDestroyTime);
    }

    public void OnPointerDown()
    {
        Tuple<Judgment, double> result = noteJudgment.Judge(this);
        DestroyMyself();
        NoteManager.Instance.ApplyJudgmentResult(new(result.Item1, result.Item2));
    }

    public void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
