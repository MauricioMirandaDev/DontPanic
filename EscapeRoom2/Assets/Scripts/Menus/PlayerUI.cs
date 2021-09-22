using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public GameObject focussedObject;

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
    public GameplayMenu gameplayMenu;
    private InteractMenu interactMenu;

    // Components
    private AudioSource audioSource;
    private EventSystem eventSystem;
    private Animator animator;
    private FirstPersonPlayer player;
    private FirstPersonPlayer.InputMode previousInput;

    private void Start()
    {
        welcomeMenu = GetComponentInChildren<WelcomeMenu>();
        welcomeMenu.gameObject.SetActive(false);

        inputMenu = GetComponentInChildren<InputMenu>();
        inputMenu.gameObject.SetActive(false);

        gameplayMenu = GetComponentInChildren<GameplayMenu>();
        gameplayMenu.gameObject.SetActive(false);

        interactMenu = GetComponentInChildren<InteractMenu>();
        interactMenu.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
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

        audioSource.PlayOneShot(menuClick);
    }

    public void KeyboardButtonSelected()
    {
        SwapMenus(inputMenu.gameObject, gameplayMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Keyboard;
        previousInput = player.inputMode;

        countdown.SetActive(true);

        audioSource.PlayOneShot(menuClick);
    }

    public void GamepadButtonSelected()
    {
        SwapMenus(inputMenu.gameObject, gameplayMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Gamepad;
        previousInput = player.inputMode;

        audioSource.PlayOneShot(menuClick);
    }

    public void ActivateInteractMenu()
    {
        SwapMenus(gameplayMenu.gameObject, interactMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Null;

        SetFocusedButton(interactMenu.exitButton);
    }

    public void DeactivateInteractMenu()
    {
        SwapMenus(interactMenu.gameObject, gameplayMenu.gameObject);

        player.inputMode = previousInput;
    }

    public void DeactivateUI()
    {
        welcomeMenu.gameObject.SetActive(false);
        inputMenu.gameObject.SetActive(false);
        gameplayMenu.gameObject.SetActive(false);
        interactMenu.gameObject.SetActive(false);

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

            SetGameplayMenuVariables(Color.red, true, "GRAB", "(hold)");
        }
        else
        {
            focussedObject = null;

            SetGameplayMenuVariables(Color.white, false, " ", " ");
        }
    }

    // Swap menus in the UI
    private void SwapMenus(GameObject previousMenu, GameObject nextMenu)
    {
        previousMenu.SetActive(false);
        nextMenu.SetActive(true);
    }

    // Set which button will be highlighted after switching menus
    private void SetFocusedButton(Button button)
    {
        eventSystem.SetSelectedGameObject(button.gameObject);
        button.OnSelect(null);
    }

    // Set how the gameplay menu will appear 
    private void SetGameplayMenuVariables(Color reticleColor, bool activateObject, string interactCommand, string interactDescription)
    {
        gameplayMenu.reticle.color = reticleColor;

        if (!activateObject)
            gameplayMenu.hint.SetText(" ");

        gameplayMenu.hint.gameObject.SetActive(activateObject);

        gameplayMenu.examineAction.SetActive(activateObject);
        gameplayMenu.interactAction.SetActive(activateObject);

        gameplayMenu.interactCommand.SetText(interactCommand);
        gameplayMenu.interactDescription.SetText(interactDescription);

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
