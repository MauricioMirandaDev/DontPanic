using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    // How fast the player will be moving
    [SerializeField]
    private float movementSpeed = 10.0f;

    // Controls movement along x-axis
    public void MoveHorizontal(float xValue)
    {
        transform.Translate(new Vector3(xValue, 0.0f, 0.0f) * movementSpeed * Time.deltaTime);
    }

    // Controls movement along z-axis
    public void MoveVertical(float zValue)
    {
        transform.Translate(new Vector3(0.0f, 0.0f, zValue) * movementSpeed * Time.deltaTime);
    }    
}
