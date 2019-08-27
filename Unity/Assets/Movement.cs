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
        private Vector3 newDirection;
        private Vector3 currentDirection;
        private float speed;

        private Vector3 newVelocity;
        private Vector3 currentVelocity; 

        [SerializeField]
        private float fCoef;



        
        void Update()
        {   
                  
            // Turn input into a direction.
            newDirection = GetInput().normalized;
            //if input accelerate to max speed
            if(newDirection != Vector3.zero){

                // var force = (newDirection - currentDirection) * fCoef;
                // newVelocity = (newDirection - force) * accelRate;
                // newVelocity += currentVelocity; 
                // newVelocity = Vector3.ClampMagnitude(newVelocity, maxSpeed);

                // newVelocity = (newDirection - (currentDirection *fCoef)) * accelRate + (currentVelocity);

                newVelocity = currentVelocity*Time.deltaTime + 0.5f*accelRate*(Time.deltaTime*Time.deltaTime)*newDirection;
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

            MovementCalc(newVelocity);
            currentDirection = newDirection;
            currentVelocity = newVelocity;
        }

        private Vector3 currentVelocity2;

        private void FixedUpdate()
        {
            return;
            currentVelocity2 *= fCoef * Time.deltaTime;
            currentVelocity2 += newDirection * accelRate * Time.deltaTime;
            currentVelocity2 = Vector3.ClampMagnitude(currentVelocity2, maxSpeed);
            MovementCalc(currentVelocity2);
        }
        

        Vector3 GetInput()
        {
            return  new Vector3( Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
        }


        void MovementCalc(Vector3 velocity)
        {
            rb.MovePosition(transform.position + velocity);
        }
        Vector3 GetAcceleration()
        {

            return Vector3.zero;
        }
    }
}
