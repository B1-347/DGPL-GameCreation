using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeKeeper : MonoBehaviour
{
    public static Action onMinuteChanged;
    public static Action onHourChanged;

    public static int minute { get; private set; }
    public static int hour { get; private set; }
    public static string meridiem { get; private set; } //AM or PM change
    public static string time { get; private set; } //Time displayed in UI

    private float _minuteToRealTime = 0.5f;
    private float _timer;

    void Start()
    {
        minute = 0;
        hour = 7;
        meridiem = "AM";
        _timer = _minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0)
        {
            minute++;
            onMinuteChanged?.Invoke();

            if (minute >= 60)
            {
                hour++;
                minute = 0;
                onHourChanged?.Invoke();

                if (hour == 12)
                {
                    if (meridiem == "AM") meridiem = "PM";
                    else meridiem = "AM";
                }
                else if (hour >= 13) hour = 1;
            }

            time = $"{hour:00}:{minute:00} {meridiem}";

            _timer = _minuteToRealTime;
        }

    }
}
