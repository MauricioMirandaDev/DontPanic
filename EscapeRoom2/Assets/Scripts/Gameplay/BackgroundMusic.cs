using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Music that opens the game
    [SerializeField]
    private AudioClip introMusic;

    // Music during the opening sequence
    [SerializeField]
    private AudioClip startMusic;

    // Music during the countdown
    [SerializeField]
    private AudioClip gameMusic;

    private AudioSource bgmAudioSource;

    private void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();

        bgmAudioSource.PlayOneShot(introMusic);
    }

    public void PlayStartMuisc()
    {
        bgmAudioSource.Stop();

        bgmAudioSource.PlayOneShot(startMusic);
    }

    public void PlayGameMusic()
    {
        bgmAudioSource.Stop();

        bgmAudioSource.PlayOneShot(gameMusic);
    }

    public void StopMusic()
    {
        bgmAudioSource.Stop();
    }
}
