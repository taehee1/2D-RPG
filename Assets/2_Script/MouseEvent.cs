using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject potionUi;
    public GameObject powerUi;
    public GameObject battleUi;

    void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "PowerNPC")
                {
                    powerUi.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "PotionNPC")
                {
                    potionUi.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "BattleNPC")
                {
                    battleUi.SetActive(true);
                }
            }
        }
    }
}