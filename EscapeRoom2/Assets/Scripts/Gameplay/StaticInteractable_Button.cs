using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_Button : StaticInteractable
{
    [SerializeField]
    private InteractMenu interactMenu;

    [SerializeField]
    private AudioClip buttonPress;

    [SerializeField]
    private StaticInteractable_Door correspondingDoor;

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

    public void ButtonPressed()
    {
        player.playerUI.SwapMenus(interactMenu.gameObject, player.playerUI.gameplayMenu.gameObject);

        player.inputMode = player.playerUI.previousInput;

        player.playerUI.uiAudioSource.PlayOneShot(buttonPress);

        correspondingDoor.OpenDoor();

        Destroy(interactMenu.gameObject);
        this.gameObject.layer = 0;
    }
}
