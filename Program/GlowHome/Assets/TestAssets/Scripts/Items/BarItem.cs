using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarItem : Interactable
{
    [SerializeField] private bool _active;   //If device is on
    [SerializeField] private UnityEvent _on; //What to do if on
    [SerializeField] private UnityEvent _off;//What to do if off
    private int _timeTaken;

    public void Awake()
    {
        type = itemType.BAR;
        _active = false;
        _timeTaken = 0;
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

    private void OnEnable()
    {
        TimeKeeper.onMinuteChanged += Check;
    }
    private void OnDisable()
    {
        TimeKeeper.onMinuteChanged -= Check;
    }
    private void Check()
    {
        if (_active) _timeTaken++;
        else _timeTaken--;

        if (_timeTaken >= duration) _timeTaken = duration;
        else if (_timeTaken <= 0) _timeTaken = 0;
        print(_timeTaken);
    }
}
