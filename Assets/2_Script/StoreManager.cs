using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public InventoryItemData[] items;
    public GameObject purchaseUi;
    public Image itemImage;
    public Text itemNameText;
    public Text itemCoinText;
    public Text itemExplainText;

    private Dictionary<string, InventoryItemData> itemDictionary;
    private string selectedItemId;

    private void Start()
    {
        itemDictionary = new Dictionary<string, InventoryItemData>();
        foreach (InventoryItemData item in items)
        {
            itemDictionary[item.itemId] = item;
        }
    }

    public void SelectItem(string itemId)
    {
        if (itemDictionary.TryGetValue(itemId, out InventoryItemData selectedItem))
        {
            purchaseUi.SetActive(true);
            itemImage.sprite = selectedItem.itemImage;
            itemNameText.text = selectedItem.itemName;
            itemCoinText.text = $"({selectedItem.itemPrice:N0} Point)";
            itemExplainText.text = selectedItem.itemDescription;

            selectedItemId = itemId;
        }
        else
        {
            Debug.LogError("Item ID not found: " + itemId);
        }
    }

    public void Purchase()
    {
        InventoryItemData selectedItem = itemDictionary[selectedItemId];
        if (GameManager.Instance.PlayerStat.coin >= selectedItem.itemPrice)
        {
            if (BackPackManager.instance.AddItem(selectedItem))
            {
                GameManager.Instance.PlayerStat.coin -= selectedItem.itemPrice;
                PopupMsgManager.instance.ShowPopupMessage("구매 성공");
            }
            else
            {
                PopupMsgManager.instance.ShowPopupMessage("BackPack에 빈 공간이 없습니다.");
            }
        }
        else
        {
            PopupMsgManager.instance.ShowPopupMessage($"잔액이 부족합니다. 잔액 : {GameManager.Instance.PlayerStat.coin}");
        }
    }
}
