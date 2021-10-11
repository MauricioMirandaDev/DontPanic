using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    // Public variables
    public GameObject focussedObject;
    public GameplayMenu gameplayMenu;
    public AudioSource uiAudioSource;
    public Animator animator;
    public FirstPersonPlayer.InputMode previousInput;
    public AudioClip menuClick;

    // Variables
    [Header("Objects")]
    [SerializeField]
    private GameObject countdown;

    [SerializeField]
    private BackgroundMusic backgroundMusic;

    [Header("Components")]
    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private Animator hallwayDoor;

    [SerializeField]
    private BoxCollider hallwayCollider;

    [Header("Variables")]
    [SerializeField]
    private AudioClip alarm;

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

    private EventSystem eventSystem;
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

    // Exit the welcome menu at the start of the game
    public void PressEnterButtonSelected()
    {
        SwapMenus(welcomeMenu.gameObject, inputMenu.gameObject);

        SetFocusedButton(inputMenu.keyboardButton);

        uiAudioSource.PlayOneShot(menuClick);
    }

    // Set the input mode to keyboard and mouse
    public void KeyboardButtonSelected()
    {
        SwapMenus(inputMenu.gameObject, gameplayMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Keyboard;
        previousInput = player.inputMode;

        uiAudioSource.PlayOneShot(menuClick);
    }

    // Set the input mode to gamepad
    public void GamepadButtonSelected()
    {
        SwapMenus(inputMenu.gameObject, gameplayMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Gamepad;
        previousInput = player.inputMode;

        uiAudioSource.PlayOneShot(menuClick);
    }

    // Start the countdown timer
    public void StartCountdown()
    {
        countdown.gameObject.SetActive(true);
        backgroundMusic.PlayGameMusic();

        uiAudioSource.PlayOneShot(alarm);

        hallwayDoor.SetTrigger("Start");
        hallwayCollider.enabled = false;
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

    // Deactivate the following UI elements
    public void DeactivateUI()
    {
        welcomeMenu.gameObject.SetActive(false);
        inputMenu.gameObject.SetActive(false);
        gameplayMenu.gameObject.SetActive(false);

        animator.SetTrigger("GameOver");
    }

    public void OpenEndingScene()
    {
        SceneManager.LoadScene("Ending");
    }

    // Find if the player is looking at an interactable object
    private void RayCast()
    {
        Ray ray = camera.ScreenPointToRay(gameplayMenu.reticle.transform.position);
        RaycastHit raycastHit;

        // Look for static interactables or moveable interactables 
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
        // Sets the color of the reticle
        gameplayMenu.reticle.color = color;

        // Removes hint from the screen
        if (!activateObject)
            gameplayMenu.hint.SetText(" ");

        // Activate gameplay menu and UI elements
        gameplayMenu.hint.gameObject.SetActive(activateObject);

        gameplayMenu.examineAction.SetActive(activateObject);
        gameplayMenu.interactAction.SetActive(activateObject);

        // Set how the interact control will appear
        gameplayMenu.interactCommand.SetText(interactCommand);
        gameplayMenu.interactCommand.color = color;
        gameplayMenu.interactDescription.SetText(interactDescription);
        gameplayMenu.interactDescription.color = color;

        gameplayMenu.interactIcon.color = color;

        // Dispaly icons based on which input mode is selected
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
