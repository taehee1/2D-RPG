using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Define.Player SelectedPlayer;
    public string UserID;

    private GameObject player;

    public float PlayerHP = 100f;
    public float PlayerEXP = 1f;
    public int coin = 0;
    public int aliveMonster = 0;

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
        
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectedPlayer.ToString());
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }
}