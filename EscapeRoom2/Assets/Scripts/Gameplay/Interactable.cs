using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private string playerHint;

    protected FirstPersonPlayer player;

    private void Start()
    {
        player = GameObject.Find("FirstPersonCharacter").GetComponent<FirstPersonPlayer>();
    }

    public void ProvideHint()
    {
        player.playerUI.gameplayMenu.hint.SetText(playerHint);
    }
}
