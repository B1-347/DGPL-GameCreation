using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public GameObject room;
    public List<string> eventTimes;

    private bool _isMoving;
    private int _pathIndex;
    private int _eventIndex;
    private GameObject _wayPoints;
 
    private void OnEnable()
    {
        TimeKeeper.onMinuteChanged += Check;
    }
    private void OnDisable()
    {
        TimeKeeper.onMinuteChanged -= Check;
    }

    public void Awake()
    {
        name = "master";
        _eventIndex = 0;
        _pathIndex = 1;
        _isMoving = false;
    }

    public void Start()
    {
        _wayPoints = room.transform.GetChild(room.transform.childCount - 1).gameObject;
        transform.position = _wayPoints.transform.GetChild(0).position;
    }

    public void Check()
    {
        if (TimeKeeper.time == eventTimes[_eventIndex])
        {
            _eventIndex++;
            _isMoving = true;
            if (_eventIndex > eventTimes.Count -1 )
            {
                _eventIndex = 0;
            }
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            Vector3 destination = _wayPoints.transform.GetChild(_pathIndex).transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, 2 * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.5)
            {
                _isMoving = false;
            }
        }
    }
}
