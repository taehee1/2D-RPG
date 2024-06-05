using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IdText;

    public Slider HpSlider;
    public GameObject HpImg;

    private GameObject player;
    public GameObject spawnPos;

    private void Start()
    {
        IdText.text = PlayerPrefs.GetString("ID");
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }

    private void Update()
    {
        display();
        HpImg.GetComponent<Slider>().value = GameManager.Instance.PlayerHP;
    }

    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
    }
}
