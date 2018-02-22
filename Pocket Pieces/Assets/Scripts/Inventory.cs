using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{

    public List<Item> list = new List<Item>();

    public void LogList()
    {
        foreach (Waste w in list)
        {
            Debug.Log(w.GetWasteType());
        }
    }

    public void Add(Item item)
    {
        Waste w = item as Waste;
        Waste newW = Instantiate(DataManager.Instance.waste, UIManager.Instance.transform, false);
        newW.type = w.type;
        newW.id = w.id;
        newW.Draw(1,1);
        list.Add(newW);
    }

    /*public void DrawInventory()
    {
        int index = 0;
        foreach (Waste w in list)
        {
            float xPos = index * 2.3f;
            float yPos = index * 2.3f;
            newW.Draw(xPos, yPos);
            index++;
        }
    }
    */

}
