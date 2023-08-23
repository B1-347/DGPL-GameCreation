using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]

public class DefaultItem : Interactable
{
    [SerializeField] private bool _active;   //If device is on
    [SerializeField] private UnityEvent _on; //What to do if on
    [SerializeField] private UnityEvent _off;//What to do if off

    public void Awake()
    {
        type = itemType.DEFAULT;
        duration = 0;
        _active = false;
    }

    public override void Activate()
    {
        if(!_active)
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
}
