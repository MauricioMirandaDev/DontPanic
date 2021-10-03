using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public GameObject focussedObject;

    public GameplayMenu gameplayMenu;

    public FirstPersonPlayer.InputMode previousInput;

    // Variables
    [SerializeField]
    private AudioClip menuClick;

    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private GameObject countdown;

    [SerializeField]
    private LayerMask staticLayer;

    [SerializeField]
    private LayerMask moveableLayer;

    [SerializeField]
    private float raycastDistance = 1.0f;

    [SerializeField]
    private Texture examineKeyboard;

    [SerializeField]
    private Texture interactKeyboard;

    [SerializeField]
    private Texture examineGamepad;

    [SerializeField]
    private Texture interactGamepad;

    // Menus
    private WelcomeMenu welcomeMenu;
    private InputMenu inputMenu;

    // Components
    private AudioSource uiAudioSource;
    private EventSystem eventSystem;
    private Animator animator;
    private FirstPersonPlayer player;

    private void Start()
    {
        welcomeMenu = GetComponentInChildren<WelcomeMenu>();
        welcomeMenu.gameObject.SetActive(false);

        inputMenu = GetComponentInChildren<InputMenu>();
        inputMenu.gameObject.SetActive(false);

        gameplayMenu = GetComponentInChildren<GameplayMenu>();
        gameplayMenu.gameObject.SetActive(false);

        uiAudioSource = GetComponent<AudioSource>();
        eventSystem = GetComponent<EventSystem>();
        player = GetComponentInParent<FirstPersonPlayer>();
        animator = GetComponent<Animator>();

        SetFocusedButton(welcomeMenu.pressEnterButton);
    }

    private void Update()
    {
        if (gameplayMenu.gameObject.activeSelf)
            RayCast();
    }

    public void StartGame()
    {
        welcomeMenu.gameObject.SetActive(true);
    }

    public void PressEnterButtonSelected()
    {
        SwapMenus(welcomeMenu.gameObject, inputMenu.gameObject);

        SetFocusedButton(inputMenu.keyboardButton);

        uiAudioSource.PlayOneShot(menuClick);
    }

    public void KeyboardButtonSelected()
    {
        SwapMenus(inputMenu.gameObject, gameplayMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Keyboard;
        previousInput = player.inputMode;

        countdown.SetActive(true);

        uiAudioSource.PlayOneShot(menuClick);
    }

    public void GamepadButtonSelected()
    {
        SwapMenus(inputMenu.gameObject, gameplayMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Gamepad;
        previousInput = player.inputMode;

        uiAudioSource.PlayOneShot(menuClick);
    }


    // Swap menus in the UI
    public void SwapMenus(GameObject previousMenu, GameObject nextMenu)
    {
        previousMenu.SetActive(false);
        nextMenu.SetActive(true);
    }

    // Set which button will be highlighted after switching menus
    public void SetFocusedButton(Button button)
    {
        eventSystem.SetSelectedGameObject(button.gameObject);
        button.OnSelect(null);
    }

    public void DeactivateUI()
    {
        welcomeMenu.gameObject.SetActive(false);
        inputMenu.gameObject.SetActive(false);
        gameplayMenu.gameObject.SetActive(false);

        animator.SetTrigger("GameOver");
    }

    // Find if the player is looking at an interactable object
    private void RayCast()
    {
        Ray ray = camera.ScreenPointToRay(gameplayMenu.reticle.transform.position);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, raycastDistance, staticLayer))
        {
            focussedObject = raycastHit.transform.gameObject;

            SetGameplayMenuVariables(Color.yellow, true, "INTERACT", "(tap)");
        }
        else if (Physics.Raycast(ray, out raycastHit, raycastDistance, moveableLayer))
        {
            focussedObject = raycastHit.transform.gameObject;

            SetGameplayMenuVariables(Color.magenta, true, "GRAB", "(hold)");
        }
        else
        {
            focussedObject = null;

            SetGameplayMenuVariables(Color.white, false, " ", " ");
        }
    }

    // Set how the gameplay menu will appear 
    private void SetGameplayMenuVariables(Color color, bool activateObject, string interactCommand, string interactDescription)
    {
        gameplayMenu.reticle.color = color;

        if (!activateObject)
            gameplayMenu.hint.SetText(" ");

        gameplayMenu.hint.gameObject.SetActive(activateObject);

        gameplayMenu.examineAction.SetActive(activateObject);
        gameplayMenu.interactAction.SetActive(activateObject);

        gameplayMenu.interactCommand.SetText(interactCommand);
        gameplayMenu.interactCommand.color = color;
        gameplayMenu.interactDescription.SetText(interactDescription);
        gameplayMenu.interactDescription.color = color;

        gameplayMenu.interactIcon.color = color;

        switch (player.inputMode)
        {
            case FirstPersonPlayer.InputMode.Keyboard:
                gameplayMenu.examineIcon.texture = examineKeyboard;
                gameplayMenu.interactIcon.texture = interactKeyboard;
                break;
            case FirstPersonPlayer.InputMode.Gamepad:
                gameplayMenu.examineIcon.texture = examineGamepad;
                gameplayMenu.interactIcon.texture = interactGamepad;
                break;
            default:
                break;
        }
    }
}
