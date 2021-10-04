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

    public override void InteractAction()
    {
        player.playerAudioSource.PlayOneShot(doorLocked);
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

    public void PlaySoundEffect(AudioClip sound)
    {
        player.playerAudioSource.PlayOneShot(sound);
    }
}
