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

    private void Update()
    {
         var newDirection = GetInput().normalized;

        // speed = speed * GetNewDirectionRatio(dir) + accel*Time.deltaTime;
        // speed = Mathf.Min (speed, maxSpeed);

        // currentVelocity = speed*dir;

        // rb.MovePosition(transform.position + currentVelocity);

        if(newDirection != Vector3.zero)
            currentVelocity += (accel * (newDirection - oldDirection * fCoef)) * Time.deltaTime;
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

    private float GetNewDirectionRatio (Vector3 newDirection) 
    {
        float angle = Vector3.Angle (newDirection, oldDirection);
        float ratio = 1.0f - angle / 180.0f;
        return ratio;
    }
 
}
