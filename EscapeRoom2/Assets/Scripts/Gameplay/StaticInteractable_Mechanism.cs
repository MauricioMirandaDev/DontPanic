using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_Mechanism : StaticInteractable
{
    // The door this mechanism opens
    [SerializeField]
    protected StaticInteractable_Door correspondingDoor;
}
