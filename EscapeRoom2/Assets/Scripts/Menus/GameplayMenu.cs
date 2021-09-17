using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayMenu : MonoBehaviour
{
    public Image reticle;

    public TMP_Text hint;

    public GameObject examineAction;
    public GameObject interactAction;

    public TMP_Text examineCommand;
    public TMP_Text interactCommand;
    public TMP_Text interactDescription;

    public RawImage examineIcon;
    public RawImage interactIcon;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }
}
