using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

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

        firstPersonInputActions.PlayerKeyboardandMouse.Examine.performed += Examine;
        firstPersonInputActions.PlayerKeyboardandMouse.Examine.Enable();

        firstPersonInputActions.PlayerKeyboardandMouse.Interact.performed += Interact;
        firstPersonInputActions.PlayerKeyboardandMouse.Interact.canceled += FinishInteract;
        firstPersonInputActions.PlayerKeyboardandMouse.Interact.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        look.Disable();
        firstPersonInputActions.PlayerKeyboardandMouse.Examine.Disable();
        firstPersonInputActions.PlayerKeyboardandMouse.Interact.Disable();
    }

    protected override void Examine(InputAction.CallbackContext callbackContext)
    {
        if (playerUI.focussedObject != null)
            playerUI.gameplayMenu.hint.SetText(playerUI.focussedObject.GetComponent<Interactable>().playerHint);
    }

    protected override void Interact(InputAction.CallbackContext callbackContext)
    {
        if (playerUI.focussedObject != null)
        {
            if (callbackContext.interaction is TapInteraction && playerUI.focussedObject.gameObject.CompareTag("Static"))
                playerUI.ActivateInteractMenu();
            else if (callbackContext.interaction is HoldInteraction && playerUI.focussedObject.gameObject.CompareTag("Moveable"))
            {
                playerUI.gameplayMenu.gameObject.SetActive(false);

                interactControl.selectedObject = playerUI.focussedObject;
                interactControl.Grab();
            }
        }
    }

    protected override void FinishInteract(InputAction.CallbackContext callbackContext)
    {
        playerUI.gameplayMenu.gameObject.SetActive(true);
        interactControl.LetGo();
    }
}
