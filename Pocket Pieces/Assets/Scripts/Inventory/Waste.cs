using UnityEngine;

[CreateAssetMenu(fileName = "New Waste", menuName = "Inventory/Waste")]
public class Waste : Item
{
    public int condition;
    public bool selected = false;
    private int index = -1;

    // Called when the item is pressed in the inventory
    public override void Select()
    {
        // Item Selected
        if (selected == false)
        {
            selected = true;
            GameManager.dataManager.SelectWaste(this);
            Debug.Log("Selected " + name);
        }
        else if (selected == true)
        {
            selected = false;
            GameManager.dataManager.DeselectWaste(this);
            Debug.Log("Deselected " + name);
        }
        else
        {
            Debug.Log("wtf happened?");
        }
        FindObjectOfType<InventoryUI>().UpdateSelected();
    }
}