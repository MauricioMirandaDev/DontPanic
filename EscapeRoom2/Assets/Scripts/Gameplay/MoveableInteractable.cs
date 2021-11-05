using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableInteractable : Interactable
{
    private Rigidbody objectRigidbody;
    private Collider objectCollider;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectCollider = GetComponent<Collider>();
    }

    // Move to the player's grab position
    public void PickUp()
    {
        player.playerUI.gameplayMenu.gameObject.SetActive(false);
        player.grahCollider.enabled = true;

        this.gameObject.transform.parent = player.transform;
        this.gameObject.transform.position = player.grabPosition.position;
        this.objectCollider.enabled = false;
        this.objectRigidbody.isKinematic = true;
    }

    // Drop the floor when player lets go of object
    public void Drop()
    {
        player.playerUI.gameplayMenu.gameObject.SetActive(true);
        player.grahCollider.enabled = false;

        this.gameObject.transform.parent = null;
        this.objectCollider.enabled = true;
        this.objectRigidbody.isKinematic = false;
    }
}
