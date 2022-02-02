using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Values")]
    [SerializeField] float speed = 25f;
    [SerializeField] float maxAcceleration = 5f;
    [SerializeField] float maxVelocityMag = 100f;

    Rigidbody2D rb;

    PlayerInputActions playerInputActions;

    //Inputs
    Vector2 movement;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions(); //Create Input Actions object
        playerInputActions.DisableInput.Enable(); //Enable DisableInputs Map
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GatherInputValues();
    }

    private void FixedUpdate()
    {
        ProcessInput();
    }

    void GatherInputValues()
    {
        movement = playerInputActions.Gameplay.Movement.ReadValue<Vector2>();
    }

    void ProcessInput()
    {
        Movement(); //process movement
    }

    void Movement()
    {
        //Get force vector
        Vector2 force = movement * speed;

        if (force == Vector2.zero)
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
