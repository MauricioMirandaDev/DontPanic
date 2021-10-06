using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_MechanismWithUI : StaticInteractable_Mechanism
{
    [SerializeField]
    protected InteractMenu interactMenu;

    [SerializeField]
    protected AudioClip buttonPress;

    public override void InteractAction()
    {
        player.playerUI.SwapMenus(player.playerUI.gameplayMenu.gameObject, interactMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Null;

        player.playerUI.SetFocusedButton(interactMenu.exitButton);
    }

    public virtual void ExitInteractMenu()
    {
        player.playerUI.SwapMenus(interactMenu.gameObject, player.playerUI.gameplayMenu.gameObject);

        player.inputMode = player.playerUI.previousInput;

        player.playerUI.uiAudioSource.PlayOneShot(player.playerUI.menuClick);
    }

    public virtual void ButtonPressed(int value)
    {

    }

    protected void PuzzleSolved()
    {
        player.playerUI.SwapMenus(interactMenu.gameObject, player.playerUI.gameplayMenu.gameObject);

        player.inputMode = player.playerUI.previousInput;

        correspondingDoor.OpenDoor();

        Destroy(interactMenu.gameObject);
        this.gameObject.layer = 0;
    }
}
