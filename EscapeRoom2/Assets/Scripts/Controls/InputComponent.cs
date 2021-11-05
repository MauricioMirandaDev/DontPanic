using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    // Input variables
    protected FirstPersonInputActions firstPersonInputActions;
    public InputAction movement;
    protected InputAction look;

    // Control variables
    protected MovementControl movementControl;
    protected LookControl lookControl;
    protected InteractControl interactControl;

    // UI variables
    protected PlayerUI playerUI;

    private void Start()
    {
        movementControl = GetComponent<MovementControl>();
        lookControl = GetComponent<LookControl>();
        interactControl = GetComponent<InteractControl>();
        playerUI = GetComponentInChildren<PlayerUI>();
    }

    private void Awake()
    {
        firstPersonInputActions = new FirstPersonInputActions();
    }

    // Examine control
    protected virtual void Examine(InputAction.CallbackContext callbackContext)
    {
    }

    // Grab control
    protected virtual void Grab(InputAction.CallbackContext callbackContext)
    {
    }

    protected virtual void FinishGrab(InputAction.CallbackContext callbackContext)
    {
    }

    // Interact control
    protected virtual void Interact(InputAction.CallbackContext callbackContext)
    {
    }
}
