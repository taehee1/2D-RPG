using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [Header("Membership")]
    public GameObject MembershipUi;
    public InputField MembershipId;
    public InputField MembershipPw;
    public InputField MembershipFind;

    [Header("Login")]
    public InputField LoginId;
    public InputField LoginPw;

    [Header("Find")]
    public GameObject FindUi;
    public InputField Find;

    [Header("ErrorMessage")]
    public GameObject ErrorUi;
    public Text ErrorMessage;

    [Header("Exit")]
    public GameObject ExitUi;

    public void MembershipBtn()
    {
        PlayerPrefs.SetString("ID", MembershipId.text);
        PlayerPrefs.SetString("PW", MembershipPw.text);
        PlayerPrefs.SetString("Find", MembershipFind.text);

        MembershipUi.SetActive(false);
    }

    public void LoginBtn()
    {
        if (PlayerPrefs.GetString("ID") != LoginId.text)
        {
            ErrorUi.SetActive(true);
            ErrorMessage.text = "���̵� ��ġ���� �ʽ��ϴ�.";
            Invoke("ErrorExit", 3f);
            return;
        }

        if (PlayerPrefs.GetString("PW") != LoginPw.text)
        {
            ErrorUi.SetActive(true);
            ErrorMessage.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
            Invoke("ErrorExit", 3f);
            return;
        }

        SceneManager.LoadScene("SelectScene");
    }

    public void FindBtn()
    {
        FindUi.SetActive(false);
        ErrorUi.SetActive(true);
        if (PlayerPrefs.GetString("Find") == Find.text)
        {
            ErrorMessage.text = $"ID : {PlayerPrefs.GetString("ID")}\nPw : {PlayerPrefs.GetString("PW")}";
        }
        else
        {
            ErrorMessage.text = "�߸��� ��Ʈ�Դϴ�";
        }
    }

    void ErrorExit()
    {
        ErrorUi.SetActive(false);
    }

    public void ExitCheck()
    {
        ExitUi.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void DonExit()
    {
        ExitUi.SetActive(false);
    }
}
