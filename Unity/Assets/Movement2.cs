using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float friction;

    [SerializeField]
    private float inputDamping;

    private Vector3 idealVelocity;
    private Vector3 currentVelocity;

    // Update is called once per frame
    void Update()
    {  
        idealVelocity = Vector3.Lerp(idealVelocity, GetInput() * maxSpeed, inputDamping * Time.deltaTime);
        currentVelocity = Vector3.MoveTowards(currentVelocity, idealVelocity, friction * Time.time);
        transform.position += currentVelocity * Time.deltaTime;
        //rb.MovePosition(transform.position + (currentVelocity * Time.deltaTime)); // making work with rb instead of transform

        Debug.DrawRay(transform.position, idealVelocity, Color.red);
        Debug.DrawRay(transform.position, currentVelocity, Color.green);
    }

    private Vector3 GetInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
    }
}
