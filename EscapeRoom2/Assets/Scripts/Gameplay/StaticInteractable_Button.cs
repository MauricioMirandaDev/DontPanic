using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_Button : StaticInteractable_MechanismWithUI
{
    // Perform action upon player pressing button
    public override void ButtonPressed(int value)
    {
        player.playerUI.uiAudioSource.PlayOneShot(buttonPress);
        PuzzleSolved();
    }
}
