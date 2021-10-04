using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_PressurePlate : StaticInteractable
{
    [SerializeField]
    private AudioClip plateFloor;

    [SerializeField]
    private StaticInteractable_Door correspondingDoor;

    private float totalMass = 0.0f;

    public override void InteractAction()
    {
        player.playerAudioSource.PlayOneShot(plateFloor);
    }

    private void OnTriggerEnter(Collider other)
    {
        totalMass += other.GetComponent<Rigidbody>().mass;
        if (totalMass >= 80.0f)
            correspondingDoor.OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        totalMass -= other.GetComponent<Rigidbody>().mass;
        if (totalMass < 80.0f)
            correspondingDoor.CloseDoor();
    }
}
