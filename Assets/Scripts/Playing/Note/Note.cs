using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    private double justTime;
    public double JustTime => justTime;
    private Action<Note> action;
    
    public void Initialize(float x, float y, double justMilliseconds, Action<Note> action)
    {
        transform.position = new Vector3 (x, y, 0);
        this.justTime = justMilliseconds;
        this.action += action;
    }
    // void OnMouseDown()
    // {
    //     Logger.Log($"Touched: {gameObject.name}");
    //     action.Invoke(this);
    // }

    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     Logger.Log($"OnPointerEnter: ${gameObject.name}");
    // }

    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Logger.Log("GetMouseButtonDown(0)");
    //     }
    // }

    public void OnPointerDown()
    {
        Logger.Log($"OnPointerDown: {gameObject.name}");
    }

}
