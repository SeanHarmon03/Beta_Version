using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 15f; // moving forward variable
    public float turnSpeed = 100f; // turning variable 

    private bool isMoving = false; // Track movement


    //Seans Code 
    private Rigidbody rb;
    public bool isFrozen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
    //End of Seans Code 


    // Update is called once per frame
    void Update()
    {
        isMoving = false;
        if (isFrozen) return;
        
        // Using W and S to move forward and backwards
        if (Input.GetKey(KeyCode.W))
        {
            // Use Rigidbody to move the truck forward
            rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.deltaTime);
            isMoving = true; // Truck is going forward 
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Use Rigidbody to move the truck backward
            rb.MovePosition(rb.position - transform.forward * moveSpeed * Time.deltaTime);
            isMoving = true; // Truck is going backwards
        }

        // This is to only allow the truck to turn when it is moving, making the turning look more natural
        if (isMoving)
        {
            // Turn left and right with A and D
            if (Input.GetKey(KeyCode.A))
            {
                // Use Rigidbody to rotate the truck
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0, -turnSpeed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                // Use Rigidbody to rotate the truck
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turnSpeed * Time.deltaTime, 0));
            }
        }
    }

    //Seans Code 
    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.CompareTag("Buildings") && !isFrozen)
        {
            StartCoroutine(FreezeTruck(2f));
        }
    }
    private IEnumerator FreezeTruck(float freezeTime)
{
    isFrozen = true;

    Vector3 originalVelocity = rb.velocity;
    Vector3 originalAngularVelocity = rb.angularVelocity;

    rb.velocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;
    rb.isKinematic = true;

    yield return new WaitForSeconds(freezeTime);

    rb.isKinematic = false;
    isFrozen = false;
}
}

