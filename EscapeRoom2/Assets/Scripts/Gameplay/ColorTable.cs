using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTable : MonoBehaviour
{
    // Position in the table array from Room3Puzzle
    [SerializeField]
    private int id = 0;

    // The block that belongs in this volume
    [SerializeField]
    private GameObject correspondingBlock;

    [SerializeField]
    private Room3Puzzle puzzle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == correspondingBlock)
            puzzle.UpdateArray(id, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == correspondingBlock)
            puzzle.UpdateArray(id, false);
    }
}
