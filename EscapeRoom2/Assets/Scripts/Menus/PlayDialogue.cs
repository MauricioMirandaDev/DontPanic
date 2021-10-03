using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayDialogue : MonoBehaviour
{


    [SerializeField]
    private AudioClip gameOver_Smoke;

    [SerializeField]
    private AudioClip gameOver_Coughing;

    [SerializeField]
    private TMP_Text dialogueBox;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    public void DisplayText(string text)
    {
        dialogueBox.SetText(text);
    }

    public void PlayGameOverAudio()
    {
        audioSource.PlayOneShot(gameOver_Smoke);
        audioSource.PlayOneShot(gameOver_Coughing);
    }
}
