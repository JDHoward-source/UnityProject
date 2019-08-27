using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class Movement : MonoBehaviour
    {
        [Header("Components")]
        [Space(2f)]
        [SerializeField]
        private Rigidbody rb;
        [Space(4f)]
        [Header("Variables")]
        [Space(2f)]

        [SerializeField]
        private float accelRate = 1.5f;

        [SerializeField]
        private float maxSpeed = 2.5f;
        [SerializeField]
        private float maxDrag;
        [SerializeField]
        private float dragMultiplier;

        private Vector3 newDirection;
        private Vector3 currentDirection;
        private float acceleration;
        private float speed;

        private Vector3 drag;

        private Vector3 newVelocity;
        private Vector3 currentVelocity; 

        [SerializeField]
        private float fCoef;



        
        void Update()
        {            
            // Turn input into a direction.
            newDirection = GetInput().normalized;

            //Check if direction matches current
            if(newDirection != currentDirection){
                //add drag if not
                drag = currentDirection.normalized * 0.2f;
            }
            else
                drag = Vector3.zero;

            //update currentDirection
    

            //if input accelerate to max speed
            if(newDirection != Vector3.zero){

                //newVelocity = (newDirection - (currentDirection *fCoef)) * accelRate + (currentVelocity);
                newVelocity = (newDirection) * accelRate + (currentVelocity - (currentDirection *fCoef));
                newVelocity = Vector3.ClampMagnitude(newVelocity, maxSpeed);
            }
            //if there is no input and velocity remains deccelerate
            else if(currentVelocity.magnitude > 0){

                newVelocity = Vector3.zero;
            }
            //else ensure velocity is none
            else{
                speed = 0;
                newVelocity = Vector3.zero;
            }

            currentDirection = newDirection;   

            
            MovementCalc(newVelocity);
        }

        Vector3 GetInput()
        {
            return  new Vector3( Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
        }


        void MovementCalc(Vector3 velocity)
        {
            rb.MovePosition(transform.position + velocity);
            currentVelocity = velocity;
        }
        Vector3 GetAcceleration()
        {

            return Vector3.zero;
        }
    }
}
