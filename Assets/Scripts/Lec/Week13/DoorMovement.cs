using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    HingeJoint joint;

    private bool isInvoked = false;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();

        JointSpring spring = joint.spring;
        spring.spring = 10f;   // kekuatan pegas
        spring.damper = 2f;    // redaman
        joint.spring = spring;

        JointMotor motor = joint.motor;
        motor.force = 50f;     // kekuatan motor
        motor.targetVelocity = 100f; // kecepatan buka
        joint.motor = motor;

    }



    // Update is called once per frame
    void Update()
    {
        float angle = transform.localEulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle;

        if (joint.useMotor == true)
        {
            if (Mathf.Abs(angle) >= 80)
            {
                Invoke("DelayTutupOtomatis", 1f);
                isInvoked = true;
            }
        }
        else
        {
            if (Mathf.Abs(angle) <= 2f)
            {
                Vector3 rot = transform.localEulerAngles;
                rot.y = 0;
                transform.localEulerAngles = rot;
                joint.useMotor = false;
                joint.useSpring = false;
                isInvoked = false;
            }
        }
    }

    void DelayTutupOtomatis()
    {
        joint.useMotor = false;
        joint.useSpring = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "hero" || collision.gameObject.tag == "enemy")
        {
            joint.useMotor = true;
            joint.useSpring = false;
        }
    }
}
