using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    public Button exitButton;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
