using UnityEngine;

// The Thing a player can create with Waste

[CreateAssetMenu(fileName = "New Waste", menuName = "Inventory/Waste")]
public class Waste : Item
{
    public int condition;

    // Called when the item is pressed in the inventory
    public override void Select()
    {
        // Item Selected
        Debug.Log("Waste is");
        base.Select();
    }

}