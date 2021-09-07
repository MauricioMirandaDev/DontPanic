using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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


    
    [SerializeField]
    private FirstPersonPlayer player;

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

        eventSystem.SetSelectedGameObject(enterButton.gameObject);
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

        player.inputMode = FirstPersonPlayer.InputMode.Keyboard;

        audioSource.PlayOneShot(menuClick);
    }

    public void GamepadButtonPressed()
    {
        inputMenu.SetActive(false);

        player.inputMode = FirstPersonPlayer.InputMode.Gamepad;

        audioSource.PlayOneShot(menuClick);
    }
}
