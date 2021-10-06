using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_Button : StaticInteractable_MechanismWithUI
{
    public override void ButtonPressed(int value)
    {
        player.playerUI.uiAudioSource.PlayOneShot(buttonPress);
        PuzzleSolved();
    }
}
