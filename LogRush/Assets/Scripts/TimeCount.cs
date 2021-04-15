using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timePassed;
    private int minutesPassed;
    private int secondsPassed;

    private void Update()
    {
        timePassed += Time.deltaTime;
        secondsPassed = Mathf.RoundToInt(timePassed % 60);
        minutesPassed = Mathf.RoundToInt(Mathf.Floor(timePassed % 3600 / 60));
        timerText.text = $"{minutesPassed}:{secondsPassed.ToString("00")}";
    }

    public float GetTimePassed()
    {
        return timePassed;
    }
}
