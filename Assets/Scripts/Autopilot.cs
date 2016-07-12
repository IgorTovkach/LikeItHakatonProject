using UnityEngine;
using System.Collections;

public class Autopilot : MonoBehaviour
{

    public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    	    
	}

    void FixedUpdate()
    {
        if (!CameraMoveControl.hasLaunched || CameraMoveControl.isLaunchingSequence) return;
        transform.rotation = Quaternion.FromToRotation(transform.forward, Target.transform.position - transform.position);
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * SpeedController.shipSpeed;
    }
}
