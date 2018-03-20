using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform waste;
    InventoryScript2 inventory;


    InventorySlot[] inventorySlots;
    void Start()
    {
        inventory = InventoryScript2.instance;
        inventory.onItemChangedCallback += UpdateUI;

        inventorySlots = waste.GetComponentsInChildren<InventorySlot>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        // Debug.Log("UPDATING UI");

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.inventoryList.Count)
            {
                inventorySlots[i].AddItem(inventory.inventoryList[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }

        }

  
    }

}
