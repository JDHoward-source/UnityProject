using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private Vector3 rotationAxis = new Vector3(0,1,0);
    private float angle = 0;
    private Vector3 radiusVec;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        radiusVec = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
    }

    // Update is called once per frame
    void Update()
    {
        angle += 0.5f / (Mathf.PI * 2f);
        radiusVec = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        velocity = Vector3.Cross(rotationAxis, radiusVec);

        velocity += GetInput().normalized;

        rb.MovePosition(transform.position + velocity);
    }   

    Vector3 GetInput()
    {
        return new Vector3( Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
    }
    

}
