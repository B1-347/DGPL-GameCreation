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
            //find the vector pointing from our position to the target
		    Vector3 _direction = (new Vector3 (_destination.x,_agent.transform.position.y,_destination.z) - transform.position).normalized;

		    //create the rotation we need to be in to look at the target
		    Quaternion _lookRotation = Quaternion.LookRotation(_direction);

		    //rotate us over time according to speed until we are in the required rotation
		    transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 3);

            Vector3 Islooking = (_destination - _agent.transform.position).normalized;
            float dotProd = Vector3.Dot(Islooking, _agent.transform.forward);
            if(dotProd > 0.9) {
                _agent.destination = _destination;
            }
        }
    }
}

public class SlerpToLookAt: MonoBehaviour
{
	//values that will be set in the Inspector
	public Transform Target;
	public float RotationSpeed;

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;
	
	// Update is called once per frame
	void Update()
	{
		//find the vector pointing from our position to the target
		_direction = (Target.position - transform.position).normalized;

		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);

		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
	}
}