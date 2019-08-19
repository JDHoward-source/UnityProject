using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 velocity;
    Vector3 position;
    float friction;
    float acceleration;
    void Update()
    {
        velocity += GetInput()*acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
        velocity -= friction * Time.deltaTime * velocity;
    }

    Vector3 GetInput()
    {
        return  new Vector3( Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;
    }
}
