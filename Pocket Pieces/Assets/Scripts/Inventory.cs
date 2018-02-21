using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : List<Waste> {

    
    public void LogList()
    {
        foreach (Waste w in this)
        {
            Debug.Log(w.GetWasteType());
        }
    }



}
