using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    private double justTime;
    public double JustTime => justTime;
    private Action<Note> sumJudgmentsAction;
    
    public void Initialize(float x, float y, double justMilliseconds, Action<Note> sumJudgmentsAction)
    {
        transform.position = new Vector3 (x, y, 0);
        this.justTime = justMilliseconds;
        this.sumJudgmentsAction += sumJudgmentsAction;
    }

    public void OnPointerDown()
    {
        sumJudgmentsAction.Invoke(this);
    }

}
