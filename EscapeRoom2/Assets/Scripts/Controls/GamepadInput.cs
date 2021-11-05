using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GamepadInput : InputComponent
{
    private void FixedUpdate()
    {
        // Set move direction from input
        movementControl.MoveHorizontal(movement.ReadValue<Vector2>().x);
        movementControl.MoveVertical(movement.ReadValue<Vector2>().y);

        // Set look rotation from input
        lookControl.GamepadLookHorizontal(look.ReadValue<Vector2>().x);
        lookControl.GamepadLookVertical(look.ReadValue<Vector2>().y);
    }

    private void OnEnable()
    {
        movement = firstPersonInputActions.PlayerGamepad.Move;
        movement.Enable();

        look = firstPersonInputActions.PlayerGamepad.Look;
        look.Enable();

        firstPersonInputActions.PlayerGamepad.Examine.performed += Examine;
        firstPersonInputActions.PlayerGamepad.Examine.Enable();

        firstPersonInputActions.PlayerGamepad.Grab.performed += Grab;
        firstPersonInputActions.PlayerGamepad.Grab.canceled += FinishGrab;
        firstPersonInputActions.PlayerGamepad.Grab.Enable();

        firstPersonInputActions.PlayerGamepad.Interact.performed += Interact;
        firstPersonInputActions.PlayerGamepad.Interact.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        firstPersonInputActions.PlayerGamepad.Examine.Disable();
        firstPersonInputActions.PlayerGamepad.Grab.Disable();
        firstPersonInputActions.PlayerGamepad.Interact.Disable();
    }

    protected override void Examine(InputAction.CallbackContext callbackContext)
    {
        interactControl.ExamineAction();
    }

    protected override void Grab(InputAction.CallbackContext callbackContext)
    {
        interactControl.GrabAction();
    }

    protected override void FinishGrab(InputAction.CallbackContext callbackContext)
    {
        interactControl.LetGo();
    }

    protected override void Interact(InputAction.CallbackContext callbackContext)
    {
        interactControl.InteractAction();
    }
}
