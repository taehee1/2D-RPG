using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public Text nameTxt;
    public Text featureTxt;
    public Text IdTxt;
    public Image charImage;

    public GameObject[] characters;
    public CharacterInfo[] characterInfos;
    private int charIndex = 0;

    public GameObject gameStart;
    public Text gameCountTxt;
    private bool isPlayClick = false;
    private float gameCount = 5f;

    private void Update()
    {
        if (isPlayClick)
        {
            gameCount -= Time.deltaTime;
            if (gameCount < 0)
            {
                SceneManager.LoadScene("MainScene");
            }
            gameCountTxt.text = $"�� ������ ���۵˴ϴ�. \n {gameCount:F1}";
        }
    }

    public void PlayBtn()
    {
        gameStart.SetActive(true);
        isPlayClick = true;
        GameManager.Instance.CharacterName = characters[charIndex].name;
    }

    private void Start()
    {
        SetInfo();
    }

    public void SelectCharacterBtn(string btnName)
    {
        characters[charIndex].SetActive(false);
        if (btnName == "Next")
        {
            charIndex++;
            charIndex = charIndex % characters.Length;
        }

        if (btnName == "Prev")
        {
            charIndex--;
            charIndex = charIndex % characters.Length;
            charIndex = charIndex < 0 ? charIndex + characters.Length : charIndex;
        }

        Debug.Log($"{charIndex}");
        characters[charIndex].SetActive(true);
        SetInfo();
    }

    private void SetInfo()
    {
        IdTxt.text = $"ID : {PlayerPrefs.GetString("ID")}";
        nameTxt.text = characterInfos[charIndex].Name;
        featureTxt.text = characterInfos[charIndex].Feature;
        charImage.sprite = characters[charIndex].GetComponent<SpriteRenderer>().sprite;
    }
}