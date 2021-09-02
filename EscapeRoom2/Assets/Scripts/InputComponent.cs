using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    // Input variables
    private FirstPersonInputActions firstPersonInputActions;
    private InputAction movement;
    private InputAction look;

    // Movement variables
    private MovementControl movementControl;
    private LookControl lookControl;

    private void Start()
    {
        movementControl = GetComponent<MovementControl>();
        lookControl = GetComponent<LookControl>();
    }

    private void Awake()
    {
        firstPersonInputActions = new FirstPersonInputActions();
    }

    private void FixedUpdate()
    {
        movementControl.MoveHorizontal(movement.ReadValue<Vector2>().x);
        movementControl.MoveVertical(movement.ReadValue<Vector2>().y);

        lookControl.LookHorizontal(look.ReadValue<Vector2>().x);
        lookControl.LookVertical(look.ReadValue<Vector2>().y);
    }

    private void OnEnable()
    {
        movement = firstPersonInputActions.Player.Movement;
        movement.Enable();

        look = firstPersonInputActions.Player.Look;
        look.Enable();

        firstPersonInputActions.Player.Jump.performed += PerformJump;
        firstPersonInputActions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        firstPersonInputActions.Player.Jump.Disable();
    }

    private void PerformJump(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("JUMP");
    }
}
