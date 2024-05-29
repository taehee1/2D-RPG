using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IdText;

    public Slider HpSlider;

    private GameObject player;

    private void Start()
    {
        IdText.text = GameManager.Instance.UserID;
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + GameManager.Instance.CharacterName);
        player = Instantiate(playerPrefab);
    }

    private void Update()
    {
        display();
    }

    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
    }
}
