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
    private Button startButton;

    // Game menu elements
    [SerializeField]
    private Canvas gameMenu;

    [SerializeField]
    private Button startGameButton;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        startMenu.enabled = true;
        gameMenu.enabled = false;

        eventSystem.SetSelectedGameObject(startButton.gameObject);
    }

    public void StartButtonClicked()
    {
        startMenu.enabled = false;
        gameMenu.enabled = true;

        eventSystem.SetSelectedGameObject(startGameButton.gameObject);
    }

    public void StartGameButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
