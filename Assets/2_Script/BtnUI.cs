using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnUI : MonoBehaviour
{
    public Button exitBtn;
    public Button homeBtn;
    public Button changeBtn;
    public GameObject checkPanel;
    public Text checkTxt;

    private void Start()
    {
        checkPanel.SetActive(false);
    }

    private string check;

    public void Exit()
    {
        check = "exit";
        checkPanel.SetActive(true);
        checkTxt.text = "������ �����Ͻðڽ��ϱ�?";
    }

    public void Home()
    {
        check = "home";
        checkPanel.SetActive(true);
        checkTxt.text = "����ȭ������ ���ư��ðڽ��ϱ�?";
    }
    public void Change()
    {
        check = "change";
        checkPanel.SetActive(true);
        checkTxt.text = "ĳ���� ����ȭ������ ���ư��ðڽ��ϱ�?";
    }

    public void YesBtn()
    {
        if (check == "exit")
        {
            Application.Quit();
        }
        else if (check == "home")
        {
            SceneManager.LoadScene("StartScene");
        }
        else if (check == "change")
        {
            SceneManager.LoadScene("SelectScene");
        }
    }

    public void NoBtn()
    {
        checkPanel.SetActive(false);
    }
}
