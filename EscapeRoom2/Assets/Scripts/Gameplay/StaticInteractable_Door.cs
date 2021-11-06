using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_Door : StaticInteractable
{
    [SerializeField]
    private AudioClip doorLocked;

    private Animator doorAnimator;

    private BoxCollider boxCollider;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Communicate to player the door is locked
    public override void InteractAction()
    {
        player.playerUI.uiAudioSource.PlayOneShot(doorLocked);
    }

    public void OpenDoor()
    {
        doorAnimator.SetBool("canOpen", true);
        boxCollider.enabled = false;
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("canOpen", false);
        boxCollider.enabled = true;
    }

    // Play open or close sound effect
    public void PlaySoundEffect(AudioClip sound)
    {
        player.playerUI.uiAudioSource.PlayOneShot(sound);
    }
}
