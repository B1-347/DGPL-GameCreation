using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarItem : Interactable
{
    private int _minuteCount;//Time put in
    private float _percentage;//Completion percentage
    private string _barDisplay;//Display in 00%
    
    public override void Awake()
    {
        type = itemType.BAR;
        Reset();
    }

    public override void Activate()
    {
        if (!_active)
        {
            _active = true;
            _on.Invoke();
        }
        else
        {
            _active = false;
            _off.Invoke();
        }
    }
    public override void Check()
    {
        // Increase time used and completion based on time
        if (_active)
        {
            _timeTaken++;
            _minuteCount++;
        } 
        else _minuteCount--;

        if (_minuteCount >= duration) _minuteCount = duration;
        else if (_minuteCount <= 0) _minuteCount = 0;

        _percentage = ((float)_minuteCount/duration)*100;
        _barDisplay = _percentage.ToString("0");

    }
    public override void Reset()
    {
        _active = false;
        _timeTaken = 0;
        _minuteCount = 0;
    }
    public override int State()
    {
        return (int)_percentage;
    }
}
