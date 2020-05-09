using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalController : MonoBehaviour
{
    public enum WheelType {
        Fixed,
        Free
    }

    private float timeCounter = 0;
    private const float minSpeed = 0;
   
    static public float speed = 0.1f;
    private float maxSpeed = 10.0f;
    private float positiveSpeedIncrement = 0.075f;
    private float negativeSpeedIncrement = 0.5f;

    private GameObject Bike;
    private GameObject RightPedal;
    private GameObject LeftPedal;

    private float xL;
    private float yL;
    private float zL;
    private float xR;
    private float yR;
    private float zR;

    private void Start() {
        Bike = GameObject.Find("Bike");
        RightPedal = Bike.transform.Find("Right_Pedal").gameObject;
        LeftPedal = Bike.transform.Find("Left_Pedal").gameObject;
    }

    private void FixedUpdate () {

        // Debug.Log(timeCounter);

        if (Input.GetAxis("Horizontal") != 0) // necessary? Does it save anything?
        {
            // If pressing right, check where the right pedal is through its rotation. 
            // If right pedal is between top point and bottom point, accelerate towards max speed
            // Else if right pedal is beyond bottom or before top, decelerate towards 0
            if (Input.GetAxis("Horizontal") >= 0) 
            {
                if (RightPedal.transform.localPosition.z >= 0)
                {
                    speed = Mathf.Min((speed + positiveSpeedIncrement), maxSpeed);
                }
                else 
                {
                    speed = Mathf.Max((speed - negativeSpeedIncrement), minSpeed);
                }
                timeCounter -= Time.deltaTime * speed;
            }
            // If pressing left, check where the left pedal is through its rotation. 
            // If left pedal is between top point and bottom point, accelerate towards max speed
            // Else if left pedal is beyond bottom or before top, decelerate towards 0
            else if (Input.GetAxis("Horizontal") <= 0) 
            {
                if (LeftPedal.transform.localPosition.z >= 0)
                {
                    speed = Mathf.Min((speed + positiveSpeedIncrement), maxSpeed);
                }
                else 
                {
                    speed = Mathf.Max((speed - negativeSpeedIncrement), minSpeed);
                }
                timeCounter -= Time.deltaTime * speed;
            }
        }    
        // Right pedal new position
        xR = 2.0f;
        yR = Mathf.Sin (timeCounter);
        zR = Mathf.Cos (timeCounter);
        
        // Left pedal new position
        xL = -2.0f;
        yL = Mathf.Sin (timeCounter + Mathf.PI);
        zL = Mathf.Cos (timeCounter + Mathf.PI);
    }

    private void Update() {
        // Move pedals
        RightPedal.transform.localPosition = new Vector3 (xR, yR, zR);
        LeftPedal.transform.localPosition = new Vector3 (xL, yL, zL);
    }
}
