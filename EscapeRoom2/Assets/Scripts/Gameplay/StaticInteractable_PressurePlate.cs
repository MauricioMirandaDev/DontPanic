using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_PressurePlate : StaticInteractable_Mechanism
{
    [SerializeField]
    private AudioClip plateFloor;

    private float totalMass = 0.0f;

    // Communicate to the player this object can be interacted with
    public override void InteractAction()
    {
        player.playerUI.uiAudioSource.PlayOneShot(plateFloor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            totalMass += other.GetComponent<Rigidbody>().mass;
            if (totalMass >= 80.0f)
                correspondingDoor.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            totalMass -= other.GetComponent<Rigidbody>().mass;
            if (totalMass < 80.0f)
                correspondingDoor.CloseDoor();
        }
    }
}
