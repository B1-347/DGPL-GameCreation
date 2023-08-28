using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void OnEnable()
    {
        TimeKeeper.onMinuteChanged += UpdateTime;
        TimeKeeper.onHourChanged += UpdateTime;
    }

    private void OnDisable()
    {
        TimeKeeper.onMinuteChanged -= UpdateTime;
        TimeKeeper.onHourChanged -= UpdateTime;
    }

    private void UpdateTime()
    {
        timeText.text = TimeKeeper.time;
    }

}
