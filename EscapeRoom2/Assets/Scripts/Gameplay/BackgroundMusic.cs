using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip introMusic;

    private AudioSource bgmAudioSource;

    private void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();

        bgmAudioSource.PlayOneShot(introMusic);
    }
}
