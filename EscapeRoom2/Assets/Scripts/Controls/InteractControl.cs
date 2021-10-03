using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour
{
    [SerializeField]
    private FirstPersonPlayer firstPersonPlayer;

    [SerializeField]
    private Transform grabPosition;

    private Interactable interactableObject;

    private void Start()
    {
        firstPersonPlayer = GetComponent<FirstPersonPlayer>();
    }

    public void ExamineAction()
    {
        if (firstPersonPlayer.playerUI.focussedObject != null)
            firstPersonPlayer.playerUI.focussedObject.GetComponent<Interactable>().ProvideHint();
    }

    public void InteractAction()
    {
        if (firstPersonPlayer.playerUI.focussedObject != null && firstPersonPlayer.playerUI.focussedObject.layer == 9)
            firstPersonPlayer.playerUI.focussedObject.GetComponent<StaticInteractable>().InteractAction();
    }

    public void GrabAction()
    {
        if (firstPersonPlayer.playerUI.focussedObject != null && firstPersonPlayer.playerUI.focussedObject.layer == 10)
            firstPersonPlayer.playerUI.focussedObject.GetComponent<MoveableInteractable>().PickUp();
    }

    public void LetGo()
    {
        if (firstPersonPlayer.playerUI.focussedObject != null && firstPersonPlayer.playerUI.focussedObject.layer == 10)
            firstPersonPlayer.playerUI.focussedObject.GetComponent<MoveableInteractable>().Drop();
    }
}
