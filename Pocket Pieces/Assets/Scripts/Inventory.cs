using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : List<Item> {

    
    public void LogList()
    {
        foreach (Waste w in this)
        {
            Debug.Log(w.GetWasteType());
        }
    }




}
