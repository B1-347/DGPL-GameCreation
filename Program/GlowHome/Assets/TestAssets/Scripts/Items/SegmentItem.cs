using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SegmentItem : Interactable
{
    private int _state;
    private int _minuteCount;

    [SerializeField] public List<UnityEvent> _actions = new List<UnityEvent>();

    public override void Awake()
    {
        type = itemType.SEGMENT;
        Reset();
    }

    public override void Activate()
    {
        if (!_active)
        {
            if (_state > _actions.Count/2 - 1) _state = 0;

            _active = true;
            _on.Invoke();

            _actions[_state].Invoke();

        }
    }
    public override void Check()
    {
        // Increase time used and completion based on time
        if (_active && _minuteCount >= duration)
        {
            _state++;
            _minuteCount = 0;
            _active = false;
            _off.Invoke();

            _actions[_actions.Count / 2 + _state - 1].Invoke();
        }
        else if (_active)
        {
            _timeTaken++;
            _minuteCount++;
        }
    }
    public override void Reset()
    {
        _active = false;
        _timeTaken = 0;
        _state = 0;
        _minuteCount = 0;
        
    }
}
