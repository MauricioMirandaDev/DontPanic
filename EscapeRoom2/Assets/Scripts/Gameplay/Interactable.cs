using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Hint provided to the player
    [SerializeField]
    private string playerHint;

    protected FirstPersonPlayer player;

    private void Start()
    {
        player = GameObject.Find("FirstPersonCharacter").GetComponent<FirstPersonPlayer>();
    }

    // Dispaly hint to the player
    public void ProvideHint()
    {
        player.playerUI.gameplayMenu.hint.SetText(playerHint);
    }
}
