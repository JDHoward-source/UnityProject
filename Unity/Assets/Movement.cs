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
    float acceleration = 1;
    float targetSpeed = 10;
    float maxSpeed = 12;

    float Horizontal;
    float vertical;
    void Update()
    {
        direction = GetInput();
        // Vector3 targetVelocity = transform.rotation * direction * targetSpeed;
        // if(targetVelocity.magnitude > maxSpeed)
        // {
        //     targetVelocity
        // }


        velocity = direction * acceleration * Time.deltaTime;
        velocity -= friction * Time.deltaTime * velocity;

        MovementCalc(velocity);

        
    }
    void FixedUpdate(){
    }
    void MovementCalc(Vector3 velocity)
    {
        rb.MovePosition(transform.position + velocity);
    }

    Vector3 GetInput()
    {
        Horizontal = Input.GetAxis ("Horizontal");
        vertical = Input.GetAxis ("Vertical");
        return  new Vector3( Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
    }
    // private void Update()
    // {
    //     DoMovement();
    // }
    // private void DoMovement()
    // {
    //     var inputvector = new Vector3( Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
    //     Vector3 direction = (inputvector - transform.position).normalized;
    //     rigidbody.MovePosition(transform.position + inputvector * 5f * Time.deltaTime);
     
    // }
}
