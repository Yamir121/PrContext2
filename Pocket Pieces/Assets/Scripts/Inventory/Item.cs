using UnityEngine;



//voorbeeldscript overgenomen uit Unity tutorial (adventure game unity tutorial)
// Nut van script nog onduidelijk.

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public GameObject itemObject;
    
}