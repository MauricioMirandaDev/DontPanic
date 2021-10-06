using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaticInteractable_Keypad : StaticInteractable
{
    [SerializeField]
    private InteractMenu interactMenu;

    [SerializeField]
    private AudioClip buttonPress;

    [SerializeField]
    private AudioClip fail;

    [SerializeField]
    private AudioClip pass;

    [SerializeField]
    private StaticInteractable_Door correspondingDoor;

    [SerializeField]
    private int[] password = new int[4];

    private int[] input = new int[4];

    [SerializeField]
    private TMP_Text firstNum;

    [SerializeField]
    private TMP_Text secondNum;

    [SerializeField]
    private TMP_Text thirdNum;

    [SerializeField]
    private TMP_Text fourthNum;

    private TMP_Text[] display = new TMP_Text[4];

    private int index = 0;

    private void Awake()
    {
        display[0] = firstNum;
        display[1] = secondNum;
        display[2] = thirdNum;
        display[3] = fourthNum;
    }

    public override void InteractAction()
    {
        player.playerUI.SwapMenus(player.playerUI.gameplayMenu.gameObject, interactMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Null;

        player.playerUI.SetFocusedButton(interactMenu.exitButton);
    }

    public void ExitInteractMenu()
    {
        player.playerUI.SwapMenus(interactMenu.gameObject, player.playerUI.gameplayMenu.gameObject);

        player.inputMode = player.playerUI.previousInput;

        player.playerUI.uiAudioSource.PlayOneShot(player.playerUI.menuClick);
    }

    public void ButtonPressed(int value)
    {
        input[index] = value;
        display[index].SetText(value.ToString());

        index++;
        if (index > 3)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != password[i])
                {
                    index = 0;
                    display[0].SetText("0");
                    display[1].SetText("0");
                    display[2].SetText("0");
                    display[3].SetText("0");
                    player.playerUI.uiAudioSource.PlayOneShot(fail);
                    break;
                }
                else
                {
                    player.playerUI.SwapMenus(interactMenu.gameObject, player.playerUI.gameplayMenu.gameObject);

                    player.inputMode = player.playerUI.previousInput;

                    player.playerUI.uiAudioSource.PlayOneShot(pass);

                    correspondingDoor.OpenDoor();

                    Destroy(interactMenu.gameObject);
                    this.gameObject.layer = 0;
                }
            }
        }
        else
        {
            player.playerUI.uiAudioSource.PlayOneShot(buttonPress);
        }
    }
}
