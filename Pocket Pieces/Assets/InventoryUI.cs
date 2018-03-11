using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    InventoryScript2 inventory;

    InventorySlot[] slots;

    void Start()
    {
        inventory = InventoryScript2.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
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
