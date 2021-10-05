using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTable : MonoBehaviour
{
    [SerializeField]
    private int id = 0;

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
