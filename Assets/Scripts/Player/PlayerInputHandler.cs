using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    //Scripts to send input data to
    PlayerMovement playerMovementScript;

    PlayerInputActions playerInputActions;

    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void Awake()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        playerInputActions = new PlayerInputActions(); //Create Input Actions object
    }

    private void Update()
    {
        MovementInputHandling();
    }

    private void MovementInputHandling()
    {
        Vector2 dir = playerInputActions.Gameplay.Movement.ReadValue<Vector2>();
        Debug.Log(dir);
        playerMovementScript.SetMovementDirection(dir);
    }
}
