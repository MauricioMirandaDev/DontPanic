using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour
{
    public GameObject selectedObject;

    [SerializeField]
    private Transform grabPosition;

    public void Grab()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
            selectedObject.transform.position = grabPosition.position;
            selectedObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void LetGo()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.parent = null;
            selectedObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
