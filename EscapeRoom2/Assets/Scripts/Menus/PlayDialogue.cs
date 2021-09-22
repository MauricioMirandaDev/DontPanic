using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayDialogue : MonoBehaviour
{
    [SerializeField]
    private AudioClip intro_01_Dialogue;

    [SerializeField]
    private string intro_01_Text;

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

    public void PlayDiaglogue_Intro_01()
    {
        audioSource.PlayOneShot(intro_01_Dialogue);
        dialogueBox.SetText(intro_01_Text);
    }

    public void PlayGameOverAudio()
    {
        audioSource.PlayOneShot(gameOver_Smoke);
        audioSource.PlayOneShot(gameOver_Coughing);
    }
}
