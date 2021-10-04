using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    [SerializeField]
    private FirstPersonPlayer player;

    [SerializeField]
    private BackgroundMusic backgroundMusic;

    private BoxCollider trigger;

    private void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            backgroundMusic.PlayStartMuisc();

            player.playerUI.animator.SetTrigger("StartGame");

            trigger.enabled = false;
        }
    }
}
