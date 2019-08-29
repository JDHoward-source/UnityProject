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
    private Vector3 direction;

    private float speed;

    private Vector3 currentVelocity;


    private void Update()
    {
        var dir = GetInput().normalized;

        speed = speed * GetNewDirectionRatio(dir) + accel*Time.deltaTime;
        speed = Mathf.Min (speed, maxSpeed);

        currentVelocity = speed*dir;

        rb.MovePosition(transform.position + currentVelocity); 
        Debug.DrawRay(transform.position, currentVelocity, Color.green);
        direction = dir;

    }

    Vector3 GetInput()
    {
        return  new Vector3( Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
    }

    private float GetNewDirectionRatio (Vector3 newDirection) 
    {
        float angle = Vector3.Angle (newDirection, direction);
        float ratio = 1.0f - angle / 180.0f;
        return ratio;
    }
 
}
