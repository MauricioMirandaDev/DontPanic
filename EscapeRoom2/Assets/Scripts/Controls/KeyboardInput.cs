using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : InputComponent
{
    private void FixedUpdate()
    {
        movementControl.MoveHorizontal(movement.ReadValue<Vector2>().x);
        movementControl.MoveVertical(movement.ReadValue<Vector2>().y);

        lookControl.LookHorizontal(look.ReadValue<Vector2>().x);
        lookControl.LookVertical(look.ReadValue<Vector2>().y);
    }

    private void OnEnable()
    {
        movement = firstPersonInputActions.PlayerKeyboardandMouse.Move;
        movement.Enable();

        look = firstPersonInputActions.PlayerKeyboardandMouse.Look;
        look.Enable();

        firstPersonInputActions.PlayerKeyboardandMouse.Select.performed += Select;
        firstPersonInputActions.PlayerKeyboardandMouse.Select.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        firstPersonInputActions.PlayerKeyboardandMouse.Select.Disable();
    }

    protected override void Select(InputAction.CallbackContext callbackContext)
    {
        if (playerUI.focussedObject != null)
            playerUI.hint.SetText(playerUI.focussedObject.GetComponent<Interactable>().playerHint);
    }
}
