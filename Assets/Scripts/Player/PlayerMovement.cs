using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Values")]
    [Tooltip("The player movement speed")]
    [SerializeField] float speed = 25f;

    [Tooltip("The maximum acceleration value")]
    [SerializeField] float maxAcceleration = 5f;

    [Tooltip("The maximum velocity magnitude value")] 
    [SerializeField] float maxVelocityMag = 100f;

    Rigidbody2D rb;
    Vector2 movementDir;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //DebugLogs();
    }

    private void FixedUpdate()
    {
        Movement(); //process movement
    }

    void DebugLogs()
    {
        Debug.Log("Player Velocity: " + rb.velocity);
    }

    //Recieve movement input from PlayerInptHandler
    public void SetMovementDirection(Vector2 movementInput)
    {
        movementDir = movementInput;
    }

    void Movement()
    {
        //Get force vector
        Vector2 force = movementDir * speed;

        if (force == Vector2.zero)
            //Stop movement
            rb.AddRelativeForce(Vector2.zero, ForceMode2D.Force);
        else
            //Apply acceleration to position
            AccelerateTo(force, maxAcceleration);

        //if the velocity is too high clamp it to max velocity
        if (rb.velocity.sqrMagnitude > maxVelocityMag * maxVelocityMag)
            rb.velocity = rb.velocity.normalized * maxVelocityMag;
    }

    //Helper function to accelerate up to a max acceleration
    void AccelerateTo(Vector2 targetVelocity, float maxAccel)
    {
        //get the change in velocity
        Vector2 deltaV = targetVelocity - rb.velocity;

        //Get the acceleration value
        Vector2 accel = deltaV / Time.deltaTime;

        //if the acceleration is greater than the max acceleration then clamp it
        if (accel.sqrMagnitude > maxAccel * maxAccel)
            accel = accel.normalized * maxAccel;

        //apply acceleraition
        rb.AddRelativeForce(accel, ForceMode2D.Force);
    }

}
