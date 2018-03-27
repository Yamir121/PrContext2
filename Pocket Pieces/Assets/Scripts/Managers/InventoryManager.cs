using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public int maxWaste = 9;
    public int maxThings = 3;

    [HideInInspector]
    public List<Item> wasteList = new List<Item>();

    [HideInInspector]
    public List<Item> thingsList = new List<Item>();

    
    public List<Item> blueprintList = new List<Item>();

    private void Start()
    {
        wasteList.Add(GameManager.dataManager.allWasteTypes[0]);
        wasteList.Add(GameManager.dataManager.allWasteTypes[1]);
        wasteList.Add(GameManager.dataManager.allWasteTypes[2]);

    }

    public bool Add(Waste waste)
    {

        if (wasteList.Count != 0 && wasteList.Count >= maxWaste)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }
        else
        {
            wasteList.Add(waste);
        }
        return true;
    }

    public void Remove(Waste waste)
    {
        wasteList.Remove(waste);
    }

}
