using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3 : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float accel;
    [SerializeField]
    private float turningAccel;

    [SerializeField]
    private float deccel;
    [SerializeField]
    private Vector3 oldDirection;


    private Vector3 currentVelocity;
    [SerializeField]
    private float fCoef;

    private float dot;
    private float angle;
    private Vector3 a;

    private float currentMag;

    private void Update()
    {
        var newDirection = GetInput().normalized;

        if(newDirection != Vector3.zero)
        {
            dot = Vector3.Dot(newDirection.normalized, currentVelocity.normalized);
            angle = Mathf.Acos(dot);
            a = accel * (newDirection);
            currentMag = currentVelocity.magnitude;
            if( angle > 0.7)//if angle difference is greater than 45 character needs to decellerate at a rate and then move in new direction.
            {
                currentMag = currentVelocity.magnitude;
            }

            currentVelocity += a * Time.deltaTime;
        }
        else
        {
            currentVelocity -= (deccel * currentVelocity) * Time.deltaTime;
        }

        currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxSpeed);
        

        rb.MovePosition(transform.position + currentVelocity * Time.deltaTime);

        Debug.DrawRay(transform.position, currentVelocity, Color.green);

        oldDirection = newDirection;
    }
    Vector3 GetInput()
    {
        return  new Vector3( Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
    }
 
}
