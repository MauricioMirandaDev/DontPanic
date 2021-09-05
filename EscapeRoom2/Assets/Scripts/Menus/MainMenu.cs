using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Event system
    [SerializeField]
    private EventSystem eventSystem;


    // Start menu elements
    [SerializeField]
    private Canvas startMenu;

    [SerializeField]
    private Button enterButton;


    // Game menu elements
    [SerializeField]
    private Canvas gameMenu;

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button optionsButton;


    // Options menu elements
    [SerializeField]
    private Canvas optionsMenu;

    [SerializeField]
    private Button returnButton;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ActivateMenu(true, false, false, enterButton);
    }

    public void SetGameMenuActive()
    {
        ActivateMenu(false, true, false, startButton);
    }

    public void SetOptionsMenuActive()
    {
        ActivateMenu(false, false, true, returnButton);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ActivateMenu(bool startMenuActive, bool gameMenuActive, bool optionsMenuActive, Button firstSelectedButton)
    {
        startMenu.enabled = startMenuActive;
        gameMenu.enabled = gameMenuActive;
        optionsMenu.enabled = optionsMenuActive;

        eventSystem.SetSelectedGameObject(firstSelectedButton.gameObject);
    }
}
