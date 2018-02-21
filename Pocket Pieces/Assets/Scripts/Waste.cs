using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour {

    private DataManager.WasteType type;

    public Waste(DataManager.WasteType t)
    {
        this.type = t;
    }

    public DataManager.WasteType GetWasteType()
    {
        return this.type;
    }

}
