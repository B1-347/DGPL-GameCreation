using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public string characterName;
    public GameObject room;
    public List<string> eventTimes;
    public List<GameObject> eventlocations;
    public List<int> expectations;

    private bool _isMoving;
    private NavMeshAgent _agent;
    private Vector3 _destination;
    private GameObject _destinationOBJ;
    private int _satisfaction;
 
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
        _satisfaction = 0;
    }
    
    public void Check()
    {
        if ( eventTimes.Contains(TimeKeeper.time))
        {
            _isMoving = true;
            _destinationOBJ = eventlocations[eventTimes.IndexOf(TimeKeeper.time)];
            _destination = _destinationOBJ.transform.position;
        }
    }

    private void Update()
    {
        //find the vector pointing from our position to the target
		Vector3 _direction = (new Vector3 (_destination.x,_agent.transform.position.y,_destination.z) - transform.position).normalized;

		if (_direction != Vector3.zero) {
            //create the rotation we need to be in to look at the target
		    Quaternion _lookRotation = Quaternion.LookRotation(_direction);
            //rotate us over time according to speed until we are in the required rotation
		    transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 3);                    
        }

        Vector3 Islooking = (_destination - _agent.transform.position).normalized;
        float dotProd = Vector3.Dot(Islooking, _agent.transform.forward);
        
        if(dotProd > 0.9 && _destinationOBJ.GetComponents<Component>().Length > 1 && Vector3.Distance(transform.position, _destination) < 2)
        {
            //if(_destinationOBJ.State() == (int)expectations[0])_satisfaction++;
        }

        if (_isMoving)
        {
            if(dotProd > 0.9){
                _agent.destination = _destination;
            }
            if(Vector3.Distance(transform.position, _destination) < 1 )
            {
                _isMoving = false;
                print("STOP");
            }
        }
    }
}