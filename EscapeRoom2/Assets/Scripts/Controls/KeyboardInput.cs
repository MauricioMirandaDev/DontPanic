using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class KeyboardInput : InputComponent
{
    private void FixedUpdate()
    {
        // Set move direction from input
        movementControl.MoveHorizontal(movement.ReadValue<Vector2>().x);
        movementControl.MoveVertical(movement.ReadValue<Vector2>().y);

        // Set look rotation from input
        lookControl.LookHorizontal(look.ReadValue<Vector2>().x);
        lookControl.LookVertical(look.ReadValue<Vector2>().y);
    }

    private void OnEnable()
    {
        movement = firstPersonInputActions.PlayerKeyboardandMouse.Move;
        movement.Enable();

        look = firstPersonInputActions.PlayerKeyboardandMouse.Look;
        look.Enable();

        firstPersonInputActions.PlayerKeyboardandMouse.Examine.performed += Examine;
        firstPersonInputActions.PlayerKeyboardandMouse.Examine.Enable();

        firstPersonInputActions.PlayerKeyboardandMouse.Grab.performed += Grab;
        firstPersonInputActions.PlayerKeyboardandMouse.Grab.canceled += FinishGrab;
        firstPersonInputActions.PlayerKeyboardandMouse.Grab.Enable();

        firstPersonInputActions.PlayerKeyboardandMouse.Interact.performed += Interact;
        firstPersonInputActions.PlayerKeyboardandMouse.Interact.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        firstPersonInputActions.PlayerKeyboardandMouse.Examine.Disable();
        firstPersonInputActions.PlayerKeyboardandMouse.Grab.Disable();
        firstPersonInputActions.PlayerKeyboardandMouse.Interact.Disable();
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
