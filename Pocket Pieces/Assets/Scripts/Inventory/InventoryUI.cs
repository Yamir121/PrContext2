using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform waste;
    public Transform things;
    InventoryScript2 inventory;

    InventorySlot[] wasteSlots;
    InventorySlot[] thingsSlots;

    void Start()
    {
        inventory = InventoryScript2.instance;
        inventory.onItemChangedCallback += UpdateUI;

        wasteSlots = waste.GetComponentsInChildren<InventorySlot>();
        thingsSlots = things.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        // Debug.Log("UPDATING UI");

        for (int i = 0; i < wasteSlots.Length; i++)
        {
            if (i < inventory.wasteList.Count)
            {
                wasteSlots[i].AddItem(inventory.wasteList[i]);
            }
            else
            {
                wasteSlots[i].ClearSlot();
            }

        }

        for (int i = 0; i < thingsSlots.Length; i++)
        {
            if (i < inventory.wasteList.Count)
            {
                thingsSlots[i].AddItem(inventory.wasteList[i]);
            }
            else
            {
                thingsSlots[i].ClearSlot();
            }
        }
    }

}
