using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class CharacterStat
{
    public float PlayerHP = 100f;
    public float PlayerMP = 100f;
    public float PlayerEXP = 1f;
    public float PlayerDef = 1f;
    public int PlayerLv = 1;
    public int coin = 0;

}

public class GameManager : MonoBehaviour
{
    //public string CharacterName;
    public Define.Player SelectedPlayer;
    public string UserID;
    public CharacterStat PlayerStat = new CharacterStat();
    [HideInInspector]
    public GameObject player;

    public GameObject HpImg;

    public Character Character
    {
        get { return player.GetComponent<Character>();}
    }
    
    public Attack CharacterAttack
    {
        get { return Character.attackObj.GetComponent<Attack>();}
    }

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
        HpImg.GetComponent<Slider>().value = PlayerStat.PlayerHP;
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectedPlayer.ToString());
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }
}