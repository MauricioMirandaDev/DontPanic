using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayMenu : MonoBehaviour
{
    public Image reticle;

    public TMP_Text hint;

    public GameObject examineWindow;
    public GameObject actionWindow;

    public TMP_Text examineCommand;
    public TMP_Text actionCommand;
    public TMP_Text actionDescription;

    public RawImage examineIcon;
    public RawImage actionIcon;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }
}
