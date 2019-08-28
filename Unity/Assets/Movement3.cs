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
    private float accelRate;

    private Vector3 currentVelocity;

    private void Update()
    {
        var dir = GetInput().normalized * maxSpeed;

        //currentVelocity = currentVelocity +  dir*accelRate*Time.deltaTime;
        //currentVelocity = ((currentVelocity + dir)*accelRate)*Time.deltaTime;
        rb.MovePosition(transform.position + currentVelocity); 
        Debug.DrawRay(transform.position, currentVelocity, Color.green);

    }

    Vector3 GetInput()
    {
        return  new Vector3( Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
    }
}
