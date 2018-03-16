    using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform waste;
    public Transform things;
    InventoryScript2 inventory;

    //InventorySlot[] wasteSlots;
    

    void Start()
    {
        inventory = InventoryScript2.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = waste.GetComponentsInChildren<InventorySlot>();
        thingsSlots = things.GetComponentInChildren<inventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        // Debug.Log("UPDATING UI");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
