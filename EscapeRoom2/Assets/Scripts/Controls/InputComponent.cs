using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InputComponent : MonoBehaviour
{
    // Input variables
    protected FirstPersonInputActions firstPersonInputActions;
    public InputAction movement;
    protected InputAction look;

    // Movement variables
    protected MovementControl movementControl;
    protected LookControl lookControl;

    // UI variables
    protected PlayerUI playerUI;

    [SerializeField]
    private float hintLength = 1.0f;

    private void Start()
    {
        movementControl = GetComponent<MovementControl>();
        lookControl = GetComponent<LookControl>();
        playerUI = GetComponentInChildren<PlayerUI>();
    }

    private void Awake()
    {
        firstPersonInputActions = new FirstPersonInputActions();
    }

    protected virtual void Select(InputAction.CallbackContext callbackContext)
    {
    }
}
