using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_Poster : StaticInteractable_MechanismWithUI
{
    private void Awake()
    {
        correspondingDoor = null;
        buttonPress = null;
    }
}
