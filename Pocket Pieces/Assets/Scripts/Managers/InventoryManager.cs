using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //public delegate void OnItemChanged();
    //public OnItemChanged onItemChangedCallback; //wordt getriggerd als er iets in de inventory veranderd

    public int maxWaste = 9;
    public int maxThings = 3;

    [HideInInspector]
    public List<Item> wasteList = new List<Item>();

    [HideInInspector]
    public List<Item> thingsList = new List<Item>();

    
    public List<Item> blueprintList = new List<Item>();


    public bool Add(Waste waste)
    {

        if (wasteList.Count >= maxWaste)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }
        else
        {
            wasteList.Add(waste);
        }

        //if (onItemChangedCallback != null)
        //    onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Waste waste)
    {
        wasteList.Remove(waste);
        //if (onItemChangedCallback != null)
        //    onItemChangedCallback.Invoke();
    }


}
