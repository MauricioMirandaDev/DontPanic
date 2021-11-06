using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticInteractable_MechanismWithUI : StaticInteractable_Mechanism
{
    // This interactable's interface
    [SerializeField]
    protected InteractMenu interactMenu;

    [SerializeField]
    protected AudioClip buttonPress;

    [SerializeField]
    protected Button highlightedButton;

    // Display this mechanism's interface
    public override void InteractAction()
    {
        player.playerUI.SwapMenus(player.playerUI.gameplayMenu.gameObject, interactMenu.gameObject);

        player.inputMode = FirstPersonPlayer.InputMode.Null;

        player.playerUI.SetFocusedButton(highlightedButton);
    }

    // Exit this mechanism's interface
    public virtual void ExitInteractMenu()
    {
        player.playerUI.SwapMenus(interactMenu.gameObject, player.playerUI.gameplayMenu.gameObject);

        player.inputMode = player.playerUI.previousInput;

        player.playerUI.uiAudioSource.PlayOneShot(player.playerUI.menuClick);
    }

    // Play this mechanism's button sound effect
    public virtual void ButtonPressed(int value)
    {
    }

    // Deactivate this mechanism's interface after puzzle is solved
    protected void PuzzleSolved()
    {
        player.playerUI.SwapMenus(interactMenu.gameObject, player.playerUI.gameplayMenu.gameObject);

        player.inputMode = player.playerUI.previousInput;

        correspondingDoor.OpenDoor();

        Destroy(interactMenu.gameObject);
        this.gameObject.layer = 0;
    }
}
