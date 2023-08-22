using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Material inactive;
    public Material active;

    void OnMouseDown()
    {
        print(GetComponent<Renderer>().material.name);
        if (GetComponent<MeshRenderer>().sharedMaterial != active)
        {
            GetComponent<Renderer>().material = active;
            print("ACTIVE");
        }
        else
        {
            GetComponent<Renderer>().material = inactive;
            print("INACTIVE");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
