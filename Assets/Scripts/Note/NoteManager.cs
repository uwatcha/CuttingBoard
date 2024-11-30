using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private Note notePrefab;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private List<JustTimeText> noteJustTimeTexts;
    [SerializeField] private Transform notes;
    void Start()
    {

    }

    void Update()
    {
        IsNowJustTime(1);
        IsNowJustTime(5);
        IsNowJustTime(10);
        IsNowJustTime(15);
        // if (IsNowJustTime(1))
        // {
        //     noteJustTimeTexts[0].Note = GenerateNote(4, 7.5f, 3);
        // }
        // else if (IsNowJustTime(5))
        // {
        //     noteJustTimeTexts[1].Note = GenerateNote(12, 7.5f, 8);
        // }
        // else if (IsNowJustTime(10))
        // {
        //     noteJustTimeTexts[2].Note = GenerateNote(4, 2.5f, 13);
        // }
        // else if (IsNowJustTime(15))
        // {
        //     noteJustTimeTexts[3].Note = GenerateNote(12, 2.5f, 18);
        // }
    }

    private bool IsNowJustTime(float justTime)
    {
        Logger.Log((justTime - Time.deltaTime * 0.9) + " < " + timeManager.GetPlayingTime() + " < " + (justTime + Time.deltaTime * 0.9));
        return Math.Abs(timeManager.GetPlayingTime() - justTime) < Time.deltaTime * 0.9;
    }
    private Note GenerateNote(float x, float y, float justTime)
    {
        Note note = Instantiate(notePrefab, notes);
        note.Initialize(x, y, justTime, timeManager);
        return note;
    }
}
