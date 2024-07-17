using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Coin")
            {
                GameManager.Instance.PlayerStat.coin += 10;
                Debug.Log(GameManager.Instance.PlayerStat.coin);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerStat.PlayerHP += 10;
                Debug.Log(GameManager.Instance.PlayerStat.PlayerHP);
                Destroy(gameObject);
            }
        }
    }
}
