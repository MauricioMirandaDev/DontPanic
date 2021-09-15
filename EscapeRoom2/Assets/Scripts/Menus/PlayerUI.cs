using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    // Welcome menu components
    [SerializeField]
    private GameObject welcomeMenu;

    [SerializeField]
    private Button enterButton;


    // Input menu components
    [SerializeField]
    private GameObject inputMenu;

    [SerializeField]
    private Button keyboardButton;

    // Gameplay menu components
    public GameObject gameplayMenu;

    [SerializeField]
    private Image reticle;

    public TMP_Text hint;

    [SerializeField]
    private GameObject examineAction;

    [SerializeField]
    private RawImage examineActionimage;

    [SerializeField]
    private Sprite examineKeyboard;

    [SerializeField]
    private Sprite examineGamepad;

    [SerializeField]
    private GameObject interactAction;

    [SerializeField]
    private RawImage interactActionImage;

    [SerializeField]
    private Sprite interactGamepad;

    [SerializeField]
    private Sprite interactKeyboard;


    // Interact menu components
    [SerializeField]
    private GameObject interactMenu;

    [SerializeField]
    private Button exitButton;

    // Gameplay components
    [SerializeField]
    private FirstPersonPlayer player;

    private FirstPersonPlayer.InputMode previousMode;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private LayerMask interactableLayer;

    [SerializeField]
    private float raycastDistance = 1.0f;

    public GameObject focussedObject;

    [SerializeField]
    private EventSystem eventSystem;


    // Audio components
    [SerializeField]
    private AudioClip menuClick;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        welcomeMenu.SetActive(true);
        inputMenu.SetActive(false);
        gameplayMenu.SetActive(false);
        interactMenu.SetActive(false);

        hint.gameObject.SetActive(false);

        eventSystem.SetSelectedGameObject(enterButton.gameObject);
    }

    private void Update()
    {
        if (gameplayMenu.activeSelf)
        {
            RayCast();
        }
    }

    public void EnterButtonPressed()
    {
        welcomeMenu.SetActive(false);
        inputMenu.SetActive(true);

        eventSystem.SetSelectedGameObject(keyboardButton.gameObject);

        audioSource.PlayOneShot(menuClick);
    }

    public void KeyboardButtonPressed()
    {
        inputMenu.SetActive(false);
        gameplayMenu.SetActive(true);

        player.inputMode = FirstPersonPlayer.InputMode.Keyboard;
        previousMode = FirstPersonPlayer.InputMode.Keyboard;

        audioSource.PlayOneShot(menuClick);
    }

    public void GamepadButtonPressed()
    {
        inputMenu.SetActive(false);
        gameplayMenu.SetActive(true);

        player.inputMode = FirstPersonPlayer.InputMode.Gamepad;
        previousMode = FirstPersonPlayer.InputMode.Gamepad;

        audioSource.PlayOneShot(menuClick);
    }

    public void ActivateInteractMenu()
    {
        gameplayMenu.SetActive(false);
        interactMenu.SetActive(true);

        player.inputMode = FirstPersonPlayer.InputMode.Null;

        eventSystem.SetSelectedGameObject(exitButton.gameObject);
        exitButton.OnSelect(null);
    }

    public void DeactivateInteractMenu()
    {
        interactMenu.SetActive(false);
        gameplayMenu.SetActive(true);

        player.inputMode = previousMode;
    }

    private void RayCast()
    {
        Ray ray = camera.ScreenPointToRay(reticle.transform.position);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, raycastDistance, interactableLayer))
        {
            focussedObject = raycastHit.transform.gameObject;

            reticle.color = Color.yellow;

            hint.gameObject.SetActive(true);

            examineAction.SetActive(true);
            interactAction.SetActive(true);
            if (focussedObject.gameObject.CompareTag("Static"))
                interactAction.GetComponentInChildren<TMP_Text>().SetText("INTERACT");
            else
                interactAction.GetComponentInChildren<TMP_Text>().SetText("GRAB");

            switch(player.inputMode)
            {
                case FirstPersonPlayer.InputMode.Keyboard:
                    examineActionimage.texture = examineKeyboard.texture;
                    interactActionImage.texture = interactKeyboard.texture;
                    break;
                case FirstPersonPlayer.InputMode.Gamepad:
                    examineActionimage.texture = examineGamepad.texture;
                    interactActionImage.texture = interactGamepad.texture;
                    break;
                default:
                    break;
            }
        }
        else
        {
            focussedObject = null;

            reticle.color = Color.white;

            hint.SetText(" ");
            hint.gameObject.SetActive(false);

            examineAction.SetActive(false);
            interactAction.SetActive(false);
        }
    }
}
