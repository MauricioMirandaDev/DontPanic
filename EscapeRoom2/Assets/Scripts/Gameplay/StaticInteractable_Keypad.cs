using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaticInteractable_Keypad : StaticInteractable_MechanismWithUI
{
    [SerializeField]
    private AudioClip fail;

    [SerializeField]
    private AudioClip pass;

    [SerializeField]
    private GameObject display;

    [SerializeField]
    private int[] password = new int[4];

    private int[] input = new int[4];

    private TMP_Text[] inputDisplay = new TMP_Text[4];

    private int index = 0;

    private void Awake()
    {
        inputDisplay = display.GetComponentsInChildren<TMP_Text>();
    }

    public override void ButtonPressed(int value)
    {
        player.playerUI.uiAudioSource.PlayOneShot(buttonPress);

        // Change display on keypad
        input[index] = value;
        inputDisplay[index].SetText(value.ToString());

        // Check the player's answer
        index++;
        if (index > 3)
        {
            CheckInput();
        }
    }

    // Determine if the player input the correct code 
    private void CheckInput()
    {
        bool solved = false;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != password[i])
            {
                index = 0;
                solved = false;

                for (int j = 0; j < inputDisplay.Length; j++)
                    inputDisplay[j].SetText("-");

                player.playerUI.uiAudioSource.PlayOneShot(fail);

                break;
            }
            else
                solved = true;
        }

        if (solved)
        {
            player.playerUI.uiAudioSource.PlayOneShot(pass);
            PuzzleSolved();
        }
    }
}
