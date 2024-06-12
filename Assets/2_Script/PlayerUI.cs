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

    public Text coinTxt;
    public Text monsterCountTxt;
    public Text SpeedTxt;
    public Text StrongTxt;

    private void Start()
    {
        IdText.text = PlayerPrefs.GetString("ID");
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }

    private void Update()
    {
        display();
        HpImg.GetComponent<Slider>().value = GameManager.Instance.PlayerHP;
        CoinDisplay();
        MonsterCount();
        Strong();
        Speed();
    }

    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
    }

    private void CoinDisplay()
    {
        coinTxt.text = $": {GameManager.Instance.coin}";
    }

    private void MonsterCount()
    {
        monsterCountTxt.text = $" {GameManager.Instance.aliveMonster}";
    }

    private void Speed()
    {
        SpeedTxt.text = $"Speed : {Character.Instance.moveSpeed}";
    }

    private void Strong()
    {
        StrongTxt.text = $"Strength : {Attack.Instance.damage}";
    }
}
