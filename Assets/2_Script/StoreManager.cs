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
        }
        else
        {
            Debug.LogError("Item ID not found: " + itemId);
        }
    }
}
