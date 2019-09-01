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
    private float deccel;
    [SerializeField]
    private Vector3 oldDirection;


    private Vector3 currentVelocity;
    [SerializeField]
    private float fCoef;

    private Vector3 diff;

    private void Update()
    {
        var newDirection = GetInput().normalized;

        diff = newDirection - oldDirection * fCoef;

        if(newDirection != Vector3.zero)
            currentVelocity += (accel * (newDirection)) * Time.deltaTime;
        else
            currentVelocity -= (deccel * currentVelocity) * Time.deltaTime;
        
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
