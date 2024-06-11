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
        checkTxt.text = "게임을 종료하시겠습니까?";
    }

    public void Home()
    {
        check = "home";
        checkPanel.SetActive(true);
        checkTxt.text = "메인화면으로 돌아가시겠습니까?";
    }
    public void Change()
    {
        check = "change";
        checkPanel.SetActive(true);
        checkTxt.text = "캐릭터 선택화면으로 돌아가시겠습니까?";
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
