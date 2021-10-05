using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3Puzzle : MonoBehaviour
{
    public bool[] tables = new bool[] { false, false, false, false, false, false };

    [SerializeField]
    private StaticInteractable_Door correspondingDoor;

    public void UpdateArray(int index, bool value)
    {
        tables[index] = value;

        for (int i = 0; i < tables.Length; i++)
        {
            if (!tables[i])
            {
                correspondingDoor.CloseDoor();
                break;
            }
            else
                correspondingDoor.OpenDoor();
        }
    }
}
