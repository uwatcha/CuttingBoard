using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    private double justTime;
    public double JustTime => justTime;
    private double selfDestroyTime;
    private Action<Note> sumJudgmentsAction;
    
    public void Initialize(float x, float y, double justMilliseconds, double selfDestroyTime, Action<Note> sumJudgmentsAction)
    {
        transform.position = new Vector3 (x, y, 0);
        this.justTime = justMilliseconds;
        this.selfDestroyTime = selfDestroyTime;
        this.sumJudgmentsAction += sumJudgmentsAction;
        Invoke(nameof(sumJudgmentsAction), (float)selfDestroyTime);
    }

    public void OnPointerDown()
    {
        CancelInvoke();
        sumJudgmentsAction.Invoke(this);
    }

}
