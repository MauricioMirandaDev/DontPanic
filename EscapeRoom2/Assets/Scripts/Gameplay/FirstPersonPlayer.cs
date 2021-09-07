using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    public enum InputMode { Keyboard, Gamepad, Null };
    public InputMode inputMode;

    private MovementControl movementControl;
    private LookControl lookControl;
    private KeyboardInput keyboardInput;
    private GamepadInput gamepadInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        movementControl = GetComponent<MovementControl>();
        lookControl = GetComponent<LookControl>();

        keyboardInput = GetComponent<KeyboardInput>();
        keyboardInput.enabled = false;

        gamepadInput = GetComponent<GamepadInput>();
        gamepadInput.enabled = false;

        inputMode = InputMode.Null;
    }

    private void FixedUpdate()
    {
        switch(inputMode)
        {
            case InputMode.Keyboard:
                keyboardInput.enabled = true;
                gamepadInput.enabled = false;
                break;
            case InputMode.Gamepad:
                keyboardInput.enabled = false;
                gamepadInput.enabled = true;
                break;
            default:
                keyboardInput.enabled = false;
                gamepadInput.enabled = false;
                break;
        }
    }
}
