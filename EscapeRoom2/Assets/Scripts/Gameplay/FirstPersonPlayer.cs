using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UB.Simple2dWeatherEffects.Standard;

public class FirstPersonPlayer : MonoBehaviour
{
    public enum InputMode { Keyboard, Gamepad, Null };
    public InputMode inputMode;

    [SerializeField]
    private Transform grabPosition;

    [SerializeField]
    private CountdownTimer countdown;

    private MovementControl movementControl;
    private LookControl lookControl;
    private KeyboardInput keyboardInput;
    private GamepadInput gamepadInput;
    private PlayerUI playerUI;
    private PlayerAnimation playerAnimation;
    private D2FogsPE knockoutGas;

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

        playerUI = GetComponentInChildren<PlayerUI>();

        playerAnimation = GetComponentInChildren<PlayerAnimation>();

        knockoutGas = GetComponentInChildren<D2FogsPE>();
        knockoutGas.enabled = false;

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

        if (countdown.isGameOver)
            GameOver();

        playerAnimation.SetRunningState(keyboardInput.movement.ReadValue<Vector2>(), gamepadInput.movement.ReadValue<Vector2>());
    }

    private void GameOver()
    {
        inputMode = InputMode.Null;
        knockoutGas.enabled = true;
        playerUI.DeactivateUI();
    }

}
