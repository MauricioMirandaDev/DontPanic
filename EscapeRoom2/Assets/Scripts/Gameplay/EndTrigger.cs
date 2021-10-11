using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField]
    private CountdownTimer countdown;

    // Stop the game when the player enters volume
    private void OnTriggerEnter(Collider other)
    {
        countdown.isGameOver = true;
        countdown.playerWon = true;
    }
}
