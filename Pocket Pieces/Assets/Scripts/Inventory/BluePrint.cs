using UnityEngine;

// The Thing a player can create with Waste

[CreateAssetMenu(fileName = "New Blueprint", menuName = "Inventory/Blueprint")]
public class BluePrint : Item
{
    public Waste ingredient1;
    public Waste ingredient2;
    public Waste ingredient3;

    public string function;
    public Thing result;

    // Called when the item is pressed in the inventory
    public override void Select()
    {
        UIManager.Instance.CreatePopUp(2,("Building this Thing costs 3 " + result.category +  " Wastes. Creating a Thing which " + function));
        Debug.Log("Blueprint is clicked");
    }

}