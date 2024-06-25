using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject dialogueUi;

    private GameObject playerObj;
    private float distance;

    public GameObject[] dialogueNumber;
    private int dindex = 0;

    private void Update()
    {
        if (playerObj == null) playerObj = GameManager.Instance.player;
        if (playerObj == null) return;

        distance = Vector2.Distance(transform.position, playerObj.transform.position);
        Debug.Log(distance);

        if (distance < 2)
        {
            dialogueUi.SetActive(true);
        }
        else
        {
            dialogueUi.SetActive(false);
        }
    }

    public void NextBtn(string name)
    {
        dialogueNumber[dindex].SetActive(false);
        if (name == "Next")
        {
            if (dindex < dialogueNumber.Length - 1)
            {
                dindex++;
            }
        }
        else if (name == "Prev")
        {
            if (dindex > 0)
            {
                dindex--;
            }
        }
        dialogueNumber[dindex].SetActive(true);
    }

    public void TownBtn()
    {
        SceneManager.LoadScene("TownScene");
    }
}
