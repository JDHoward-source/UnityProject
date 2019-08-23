using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    Vector3 velocity;
    Vector3 direction;
    float friction;
    float acceleration = 1.5f;
    float speed = 5;
    float maxSpeed = 12;

    float Horizontal;
    float vertical;

    float targetVelocity = 2f;
    float maxVelocity = 5f;

    
    void Update()
    {
        direction = GetInput();

         acceleration = (direction.normalized * GetRequiredAcceleraton(targetVelocity, 1)).sqrMagnitude;

        velocity = direction * (velocity.sqrMagnitude + (acceleration*Time.deltaTime));
        
        // Vector3 v;
        // if(velocity.sqrMagnitude > maxVelocity)
        // {
        //     v = velocity.normalized * maxVelocity;
        //     velocity = v;
        // }

        MovementCalc(velocity);
    }
    void FixedUpdate(){
    }
    void MovementCalc(Vector3 velocity)
    {
        rb.MovePosition(transform.position + velocity);
    }

     float GetRequiredAcceleraton(float aFinalSpeed, float aDrag)
    {
        return GetRequiredVelocityChange(aFinalSpeed, aDrag) / Time.fixedDeltaTime;
    }

     float GetRequiredVelocityChange(float aFinalSpeed, float aDrag)
    {
        float m = Mathf.Clamp01(aDrag * Time.fixedDeltaTime);
        return aFinalSpeed * m / (1 - m);
    }
    Vector3 GetInput()
    {
        Horizontal = Input.GetAxis ("Horizontal");
        vertical = Input.GetAxis ("Vertical");
        return  new Vector3( Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
    }


}
