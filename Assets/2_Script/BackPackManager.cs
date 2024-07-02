using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public GameObject backpack_Ui;
    public Text coinTxt;
    public Image[] itemImages;
    private InventoryItemData[] inventoryItemDatas;

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
        coinTxt.text = $"Coin : {GameManager.Instance.coin:N0}";
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
}
