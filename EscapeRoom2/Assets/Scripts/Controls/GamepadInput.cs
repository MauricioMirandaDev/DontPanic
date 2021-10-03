using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GamepadInput : InputComponent
{
    private void FixedUpdate()
    {
        movementControl.MoveHorizontal(movement.ReadValue<Vector2>().x);
        movementControl.MoveVertical(movement.ReadValue<Vector2>().y);

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

        firstPersonInputActions.PlayerGamepad.Interact.performed += Interact;
        firstPersonInputActions.PlayerGamepad.Interact.canceled += FinishInteract;
        firstPersonInputActions.PlayerGamepad.Interact.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        firstPersonInputActions.PlayerGamepad.Examine.Disable();
        firstPersonInputActions.PlayerGamepad.Interact.Disable();
    }

    protected override void Examine(InputAction.CallbackContext callbackContext)
    {
        interactControl.ExamineAction();
    }

    protected override void Interact(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.interaction is TapInteraction)
            interactControl.InteractAction();
        else if (callbackContext.interaction is HoldInteraction)
            interactControl.GrabAction();
    }

    protected override void FinishInteract(InputAction.CallbackContext callbackContext)
    {
        interactControl.LetGo();
    }
}
