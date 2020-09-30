using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour {
    public int speed = 50;
    HingeJoint hinge;
    // Use this for initialization
    void Start () {
       hinge  = gameObject.GetComponent(typeof(HingeJoint)) as HingeJoint;
    }
	
	// Update is called once per frame
	void Update () {
        var motor = hinge.motor;
        motor.force = 500;
        motor.targetVelocity = speed;
        motor.freeSpin = true;
        hinge.motor = motor;
        hinge.useMotor = true;
    }
}
