using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        //Transform aChild = transform.FindChild("Cylinder");
        //Wheel script = aChild.GetComponentInChildren<Wheel>();
        //aChild.speed = 90;
        //	aChild.gameObject.
        HingeJoint[] hingeJoints = GetComponentsInChildren<HingeJoint>();
        wheel myscript = gameObject.GetComponentInChildren<wheel>();
        myscript.speed = 90;
        //Debug.Log(hingeJoints.Length);
        // foreach (wheel joint in myscript) 
        myscript.speed = 90;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
