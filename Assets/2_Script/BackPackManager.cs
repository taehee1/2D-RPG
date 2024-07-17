using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public GameObject backpack_Ui;
    public Text coinTxt;
    public Image[] itemImages;
    private InventoryItemData[] inventoryItemDatas;

    private int defItemUsingCount = 0;
    private int speedItemUsingCount = 0;
    private int powerItemUsingCount = 0;

    public static BackPackManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventoryItemDatas = new InventoryItemData[itemImages.Length];
    }

    void Update()
    {
        BackPackUiOn();
        coinTxt.text = $"Coin : {GameManager.Instance.PlayerStat.coin:N0}";
    }

    private void BackPackUiOn()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            backpack_Ui.SetActive(!backpack_Ui.activeSelf);
        }
    }

    public bool AddItem(InventoryItemData item)
    {
        for (int i = 0; i < itemImages.Length; i++)
        {
            if (itemImages[i].sprite == null)
            {
                itemImages[i].sprite = item.itemImage;
                inventoryItemDatas[i] = item;
                return true;
            }
        }
        return false;
    }

    public void ItemUse()
    {
        int siblingIndex = EventSystem.current.currentSelectedGameObject.transform.parent.GetSiblingIndex();
        InventoryItemData inventoryItem = inventoryItemDatas[siblingIndex];
        if (inventoryItem == null) return;

        if (inventoryItem.itemId == "HP")
        {
            GameManager.Instance.PlayerStat.PlayerHP += 10f;
            GameManager.Instance.PlayerStat.PlayerHP = Mathf.Min(GameManager.Instance.PlayerStat.PlayerHP, 100f);
            PopupMsgManager.instance.ShowPopupMessage("체력이 10 회복되었습니다");
        }
        else if (inventoryItem.itemId == "MP")
        {
            GameManager.Instance.PlayerStat.PlayerMP += 10f;
            GameManager.Instance.PlayerStat.PlayerMP = Mathf.Min(GameManager.Instance.PlayerStat.PlayerMP, 100f);
            PopupMsgManager.instance.ShowPopupMessage("마나가 10 회복되었습니다");
        }
        else if (inventoryItem.itemId == "HP_Power")
        {
            GameManager.Instance.PlayerStat.PlayerHP += 100f;
            PopupMsgManager.instance.ShowPopupMessage("체력이 전부 회복되었습니다");
        }
        else if (inventoryItem.itemId == "MP_Power")
        {
            GameManager.Instance.PlayerStat.PlayerMP += 100f;
            PopupMsgManager.instance.ShowPopupMessage("마나가 전부 회복되었습니다");
        }
        else if (inventoryItem.itemId == "Shield")
        {
            StartCoroutine(DefItem());
        }
        else if (inventoryItem.itemId == "Boots")
        {
            StartCoroutine(SpeedItem());
        }
        else if (inventoryItem.itemId == "Sword")
        {
            StartCoroutine(PowerItem());
        }
        else if (inventoryItem.itemId == "Super")
        {
            
        }
        else
        {
            Debug.Log($"존재하지 않는 itemid[{inventoryItem.itemId}]");
            return;
        }

        inventoryItemDatas[siblingIndex] = null;
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = null;
    }

    IEnumerator DefItem()
    {
        defItemUsingCount++;
        GameManager.Instance.PlayerStat.PlayerDef *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("Def : " + GameManager.Instance.PlayerStat.PlayerDef);
        yield return new WaitForSeconds(10f);

        defItemUsingCount--;
        GameManager.Instance.PlayerStat.PlayerDef /= 2;
        if (defItemUsingCount == 0)
        {
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("Def : " + GameManager.Instance.PlayerStat.PlayerDef);
    }

    IEnumerator SpeedItem()
    {
        speedItemUsingCount++;
        GameManager.Instance.Character.moveSpeed *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("Speed : " + GameManager.Instance.Character.moveSpeed);
        yield return new WaitForSeconds(10f);

        speedItemUsingCount--;
        GameManager.Instance.Character.moveSpeed /= 2;
        if (speedItemUsingCount == 0)
        {
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("Speed : " + GameManager.Instance.Character.moveSpeed);
    }

    IEnumerator PowerItem()
    {
        powerItemUsingCount++;
        GameManager.Instance.CharacterAttack.damage *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("Damage : " + GameManager.Instance.CharacterAttack.damage);
        yield return new WaitForSeconds(10f);

        powerItemUsingCount--;
        GameManager.Instance.CharacterAttack.damage /= 2;
        if (powerItemUsingCount == 0)
        {
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("Damage : " + GameManager.Instance.CharacterAttack.damage);
    }
}
