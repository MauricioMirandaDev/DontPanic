using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMenu : MonoBehaviour
{
    public Button keyboardButton;
    public Button gamepadButton;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }
}
