using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private AudioClip footstep;

    private AudioSource modelAudioSource;
    private Animator animator;

    private void Start()
    {
        modelAudioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update animator whenever the player is moving
    public void SetRunningState(Vector2 keyboardMovement, Vector2 gamepadMovement)
    {
        if (keyboardMovement.Equals(Vector2.zero) && gamepadMovement.Equals(Vector2.zero))
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }

    public void PlayFootstep()
    {
        modelAudioSource.pitch = Random.Range(0.7f, 1.2f);
        modelAudioSource.PlayOneShot(footstep);
    }
}
