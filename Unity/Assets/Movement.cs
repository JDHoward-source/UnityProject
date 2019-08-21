using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    Vector3 velocity;
    Vector3 position;
    float friction;
    float acceleration = 1;
    void Update()
    {
        velocity += GetInput() * 0.5f * Time.deltaTime;
        position += velocity * Time.deltaTime;
        // velocity -= friction * Time.deltaTime * velocity;
        rb.MovePosition(transform.position + position);
    }

    Vector3 GetInput()
    {
        return  new Vector3( Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;
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
