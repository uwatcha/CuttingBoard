using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    private double justTime;
    public double JustTime => justTime;
    private double selfDestroyTime;
    private NoteJudgment noteJudgment = new();
    
    public void Initialize(float x, float y, double justMilliseconds, double selfDestroyTime)
    {
        transform.position = new Vector3 (x, y, 0);
        this.justTime = justMilliseconds;
        this.selfDestroyTime = selfDestroyTime;
        Invoke(nameof(DestroyMyself), (float)selfDestroyTime);
    }

    public void OnPointerDown()
    {
        Tuple<Judgment, double> result = noteJudgment.Judge(this);
        DestroyMyself();
        NoteManager.Instance.ApplyJudgmentResult(new(result.Item1, result.Item2));
    }

    private void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
