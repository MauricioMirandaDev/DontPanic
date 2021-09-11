using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

        firstPersonInputActions.PlayerGamepad.Select.performed += Select;
        firstPersonInputActions.PlayerGamepad.Select.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        firstPersonInputActions.PlayerGamepad.Select.Disable();
    }

    protected override void Select(InputAction.CallbackContext callbackContext)
    {
        if (playerUI.focussedObject != null)
            playerUI.hint.SetText(playerUI.focussedObject.GetComponent<Interactable>().playerHint);
    }
}
