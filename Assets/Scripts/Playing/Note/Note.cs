using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    private double justTime;
    public double JustTime => justTime;
    private double selfDestroyTime;
    private NoteJudgment noteJudgment = new();
    private Action<Judgment> judgmentResultApplier;
    
    public void Initialize(float x, float y, double justMilliseconds, double selfDestroyTime, Action<Judgment> judgmentResultApplier)
    {
        transform.position = new Vector3 (x, y, 0);
        this.justTime = justMilliseconds;
        this.selfDestroyTime = selfDestroyTime;
        this.judgmentResultApplier += judgmentResultApplier;
        Invoke(nameof(DestroyMyself), (float)selfDestroyTime);
    }

    public void OnPointerDown()
    {
        Judgment? result = noteJudgment.Judge(this);
        if (result != null)
        {
            DestroyMyself();
            judgmentResultApplier.Invoke(result.Value);
        }
    }

    private void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
