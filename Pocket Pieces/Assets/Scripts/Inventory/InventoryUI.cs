using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    Waste,
    Thing,
    Blueprint
};

public class InventoryUI : MonoBehaviour
{

    public InventoryType type;
    private Transform t;
    public List<Item> list;
    private InventoryManager inventoryManager;
    private InventorySlot[] inventorySlots;

    private void Start()
    {
        t = gameObject.GetComponent<Transform>();
        inventoryManager = GameManager.Instance.GetComponent<InventoryManager>();
        if (type == InventoryType.Waste)
        {
            list = inventoryManager.wasteList;
        }
        else if (type == InventoryType.Thing)
        {
            list = inventoryManager.thingsList;
        }
        else if (type == InventoryType.Blueprint)
        {
            list = inventoryManager.blueprintList;
        }

        inventorySlots = t.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("UPDATING UI");

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < list.Count)
            {
                inventorySlots[i].AddItem(list[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }

        }

  
    }

    public void UpdateSelected()
    {
        Debug.Log("UPDATING Selected");

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Selected();
        }


    }
}
