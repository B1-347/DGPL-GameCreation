using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public string name;
    public GameObject room;
    public List<string> eventTimes;
    public List<GameObject> eventlocations;

    private bool _isMoving;
    private NavMeshAgent _agent;
    private Vector3 _destination;
 
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
        _isMoving = false;
    }

    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    public void Check()
    {
        if ( eventTimes.Contains(TimeKeeper.time))
        {
            _isMoving = true;
            _destination = eventlocations[eventTimes.IndexOf(TimeKeeper.time)].transform.position;
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(_destination),
                Time.deltaTime * 100);

            //transform.LookAt(new Vector3 (_destination.x,_agent.transform.position.y,_destination.z));
                       
            //_agent.destination = _destination;
            
            
        }
    }
}
