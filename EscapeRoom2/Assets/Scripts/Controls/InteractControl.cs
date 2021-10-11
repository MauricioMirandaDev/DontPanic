using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour
{
    [SerializeField]
    private FirstPersonPlayer firstPersonPlayer;

    // Position where moveable interactables will be held
    [SerializeField]
    private Transform grabPosition;

    private Interactable interactableObject;

    private void Start()
    {
        firstPersonPlayer = GetComponent<FirstPersonPlayer>();
    }

    // Provides a hint to the player
    public void ExamineAction()
    {
        if (firstPersonPlayer.playerUI.focussedObject != null)
            firstPersonPlayer.playerUI.focussedObject.GetComponent<Interactable>().ProvideHint();
    }

    // Bring up the interface of the static interactable
    public void InteractAction()
    {
        if (firstPersonPlayer.playerUI.focussedObject != null && firstPersonPlayer.playerUI.focussedObject.layer == 9)
            firstPersonPlayer.playerUI.focussedObject.GetComponent<StaticInteractable>().InteractAction();
    }

    // Hold the moveable interactable in the grab position
    public void GrabAction()
    {
        if (firstPersonPlayer.playerUI.focussedObject != null && firstPersonPlayer.playerUI.focussedObject.layer == 10)
            firstPersonPlayer.playerUI.focussedObject.GetComponent<MoveableInteractable>().PickUp();
    }

    // Drop the moveable interactable
    public void LetGo()
    {
        if (firstPersonPlayer.playerUI.focussedObject != null && firstPersonPlayer.playerUI.focussedObject.layer == 10)
            firstPersonPlayer.playerUI.focussedObject.GetComponent<MoveableInteractable>().Drop();
    }
}
