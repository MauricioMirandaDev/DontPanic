using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayDialogue : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dialogueBox;

    private FirstPersonPlayer player;

    private AudioSource audioSource;

    private void Start()
    {
        player = GetComponentInParent<FirstPersonPlayer>();
    }

    public void PlayAudio(AudioClip audio)
    {
        player.playerUI.uiAudioSource.PlayOneShot(audio);
    }

    public void PlayVoice(AudioClip voice)
    {
        player.playerAudioSource.PlayOneShot(voice);
    }

    public void DisplayText(string text)
    {
        dialogueBox.SetText(text);
    }
}
