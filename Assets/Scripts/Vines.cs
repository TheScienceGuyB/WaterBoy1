using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour {

    public HingeJoint2D myHinge;
    public JointMotor2D motor;
    
	void Start () {
        
        InvokeRepeating("StartCo", 0, 8);

    }
	
	// Update is called once per frame
	void Update () {
       
    }

     void StartCo()
     {
        StartCoroutine(Sway());
     }

    
    IEnumerator Sway()
    {
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = 8f;
        hinge.motor = motor;
        hinge.useMotor = true;


        yield return new WaitForSeconds(4);

        HingeJoint2D hinge1 = GetComponent<HingeJoint2D>();
        JointMotor2D motor1 = hinge.motor;
        motor.motorSpeed = -8f;
        hinge.motor = motor;
        hinge.useMotor = true;
    }
}
