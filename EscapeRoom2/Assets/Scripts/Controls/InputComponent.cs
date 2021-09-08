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

    // Movement variables
    protected MovementControl movementControl;
    protected LookControl lookControl;

    private void Start()
    {
        movementControl = GetComponent<MovementControl>();
        lookControl = GetComponent<LookControl>();
    }

    private void Awake()
    {
        firstPersonInputActions = new FirstPersonInputActions();
    }

    protected virtual void Select(InputAction.CallbackContext callbackContext)
    {
    }
}
