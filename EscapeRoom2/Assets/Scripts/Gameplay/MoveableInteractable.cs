using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableInteractable : Interactable
{
    private Rigidbody objectRigidbody;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    // Move to the player's grab position
    public void PickUp()
    {
        player.playerUI.gameplayMenu.gameObject.SetActive(false);

        this.gameObject.transform.parent = player.transform;
        this.gameObject.transform.position = player.grabPosition.position;
        this.objectRigidbody.useGravity = false;
    }

    // Drop the floor when player lets go of object
    public void Drop()
    {
        player.playerUI.gameplayMenu.gameObject.SetActive(true);

        this.gameObject.transform.parent = null;
        this.objectRigidbody.useGravity = true;
    }
}
