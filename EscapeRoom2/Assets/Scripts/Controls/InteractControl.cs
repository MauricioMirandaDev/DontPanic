using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform grabPosition;

    private PlayerUI playerUI;

    private void Start()
    {
        playerUI = GetComponentInChildren<PlayerUI>();
    }

    public void DisplayHint()
    {
        if (playerUI.focussedObject != null)
            playerUI.gameplayMenu.hint.SetText(playerUI.focussedObject.GetComponent<Interactable>().playerHint);     
    }

    public void InteractAction()
    {
        if (playerUI.focussedObject != null && playerUI.focussedObject.layer == 9)
            playerUI.ActivateInteractMenu();
    }

    public void GrabAction()
    {
        if (playerUI.focussedObject != null && playerUI.focussedObject.layer == 10)
        {
            playerUI.gameplayMenu.gameObject.SetActive(false);

            playerUI.focussedObject.transform.parent = player.transform;
            playerUI.focussedObject.transform.position = grabPosition.position;
            playerUI.focussedObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void LetGo()
    {
        if (playerUI.focussedObject != null && playerUI.focussedObject.layer == 10)
        {
            playerUI.gameplayMenu.gameObject.SetActive(true);

            playerUI.focussedObject.transform.parent = null;
            playerUI.focussedObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
