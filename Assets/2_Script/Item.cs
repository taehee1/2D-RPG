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
                GameManager.Instance.coin += 10;
                Debug.Log(GameManager.Instance.coin);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHP += 10;
                Debug.Log(GameManager.Instance.PlayerHP);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Speed")
            {
                Character.Instance.moveSpeed += 5;
                Debug.Log(Character.Instance.moveSpeed);
                Invoke("BuffEnd", 5f);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Strong")
            {
                Attack.Instance.damage += 10;
                Debug.Log(Attack.Instance.damage);
                Destroy(gameObject);
            }
        }
    }

    private void BuffEnd()
    {
        Character.Instance.moveSpeed -= 10;
    }
}
