using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string CharacterName;
    public string UserID;

    public float PlayerHP = 100f;
    public float PlayerEXP = 1f;

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
}