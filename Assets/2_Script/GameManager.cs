using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string CharacterName;
    public string UserID;

    public GameObject HpImg;

    public GameObject player;

    public float PlayerHP = 100f;
    public float PlayerEXP = 1f;
    public int coin = 0;

    public static GameManager Instance;
    #region Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(Instance);
    }
    #endregion

    private void Start()
    {
        UserID = PlayerPrefs.GetString("ID");
    }

    private void Update()
    {
        HpImg.GetComponent<Slider>().value = PlayerHP;
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + GameManager.Instance.CharacterName);
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }
}