using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public bool isGameOver = false;

    [SerializeField]
    private int timeLimit = 1;

    [SerializeField]
    private TMP_Text display;

    private float actualTime;

    private void Start()
    {
        actualTime = (float)timeLimit * 60.0f;

        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if (actualTime > 0)
                actualTime -= Time.deltaTime;
            else
            {
                actualTime = 0;
                isGameOver = true;
            }

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
}
