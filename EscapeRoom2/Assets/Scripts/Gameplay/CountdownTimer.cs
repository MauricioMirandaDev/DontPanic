using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UB.Simple2dWeatherEffects.Standard;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField]
    private int timeLimit = 1;

    [SerializeField]
    private TMP_Text display;

    [SerializeField]
    private FirstPersonPlayer player;

    [SerializeField]
    private PlayerUI playerUI;

    [SerializeField]
    private D2FogsPE fog;

    private float actualTime;

    private void Start()
    {
        actualTime = (float)timeLimit * 10.0f;

        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if (actualTime > 0)
                actualTime -= Time.deltaTime;
            else
                GameOver();

            Countdown();
        }
    }

    private void Countdown()
    {
        int minutes = (int)actualTime / 60;
        int seconds = (int)actualTime % 60;
        float miliseconds = (actualTime % 1.0f) * 100.0f;

        display.SetText(string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, miliseconds));
    }

    private void GameOver()
    {
        actualTime = 0;

        player.inputMode = FirstPersonPlayer.InputMode.Null;
        fog.enabled = true;
        playerUI.DeactivateUI();
    }
}
