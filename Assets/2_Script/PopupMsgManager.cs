using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMsgManager : MonoBehaviour
{
    public static PopupMsgManager instance;
    public Text popupText;
    public float displayTime = 3f;

    private GameObject panel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        panel = popupText.transform.parent.parent.gameObject;
    }

    public void ShowPopupMessage(string message)
    {
        panel.SetActive(true);
        popupText.text = message;
        StartCoroutine(HideMessageAfterDelay());
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        popupText.text = "";
        panel.SetActive(false);
    }
}
