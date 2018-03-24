using UnityEngine;

// The Thing a player can create with Waste

[CreateAssetMenu(fileName = "New Thing", menuName = "Inventory/Thing")]
public class Thing : Item
{
    public string category;
    public string function;
    public int functionLvl;
    public int sustainabilityLvl;

    // Called when the item is pressed in the inventory
    public override void Select()
    {
        // Item Selected
        Debug.Log("Thing is");
        base.Select();
    }

}