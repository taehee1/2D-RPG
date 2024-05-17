using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public Text name;
    public Text feature;
    public Image charImage;

    public GameObject[] characters;
    private int charIndex = 0;

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
    }
}
