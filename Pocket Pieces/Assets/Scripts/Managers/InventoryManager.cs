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

    public bool Add(Item item)
    {
        Item _item = item;
        List<Item> _list;

        if (item.GetType() == typeof(Waste))
        {
            _item = item as Waste;
            _list = wasteList;
        }
        else if (item.GetType() == typeof(Thing))
        {
            _item = item as Thing;
            _list = thingsList;
        }
        else
        {
            return false;
        }

        if (_list.Count != 0 && _list.Count >= maxWaste)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }
        else
        {
            _list.Add(_item);
        }
        return true;
    }

    public bool Add(Thing thing)
    {

        if (thingsList.Count != 0 && thingsList.Count >= maxWaste)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }
        else
        {
            thingsList.Add(thing);
        }
        return true;
    }

    public void Remove(Waste waste)
    {
        wasteList.Remove(waste);
    }

}
