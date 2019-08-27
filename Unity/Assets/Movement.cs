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

                //newVelocity = (newDirection - (currentDirection *fCoef)) * accelRate + (currentVelocity);
                var curve = currentVelocity - (currentDirection *fCoef);
                newVelocity = (newDirection) * accelRate + curve;
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


            currentVelocity *= fCoef * Time.deltaTime;
            currentVelocity += newDirection * accelRate * Time.deltaTime;
            currentVelocity = Vector3.ClampMagnitude(currentVelocity, maxSpeed);

            MovementCalc(currentVelocity);

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
