using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EndingDialogue : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dialogueBox;

    [SerializeField]
    private CreditsMenu credits;

    [SerializeField]
    private EventSystem eventSystem;

    private AudioSource audioSource;
    private Animator animator;
    private CountdownTimer countdown;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        countdown = GameObject.Find("Countdown").GetComponent<CountdownTimer>();

        animator.SetBool("PlayerWon", countdown.playerWon);
    }

    public void PlayDialogue(AudioClip voice)
    {
        audioSource.PlayOneShot(voice);
    }

    public void ChangeText(string text)
    {
        dialogueBox.SetText(text);
    }

    public void SetEnding()
    {
        animator.SetBool("PlayerWon", countdown.playerWon);
    }

    public void ShowCredits()
    {
        Destroy(countdown.gameObject);

        credits.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(credits.exitButton.gameObject);
        credits.exitButton.OnSelect(null);
    }
}
