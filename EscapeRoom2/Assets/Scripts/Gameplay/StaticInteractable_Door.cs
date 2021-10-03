using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable_Door : StaticInteractable
{
    public Animator doorAnimator;

    [SerializeField]
    private AudioClip doorLocked;

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
        doorAnimator.SetTrigger("doorOpen");
        boxCollider.enabled = false;
    }

    public void PlaySoundEffect(AudioClip sound)
    {
        player.playerAudioSource.PlayOneShot(sound);
    }
}
