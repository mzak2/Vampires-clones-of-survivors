using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    TimerUI timerUI;

    private void Awake()
    {
        timerUI = FindObjectOfType<TimerUI>();
    }

    private void Update()
    {
        time += Time.deltaTime; //tracks time from start of scene for progression
        timerUI.UpdateTime(time); //set time to UI
    }
}
