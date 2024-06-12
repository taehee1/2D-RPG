using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUi : MonoBehaviour
{
    public GameObject btnUi;

    private bool isBtnOn = false;

    private void BtnUiOn()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isBtnOn == false)
        {
            btnUi.SetActive(true);
            isBtnOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isBtnOn == true)
        {
            btnUi.SetActive(false);
            isBtnOn = false;
        }
    }

    private void Update()
    {
        BtnUiOn();
    }
}
