using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public enum WasteType { Circle, Triangle, Rectangle };

    private Dictionary<int, WasteType> qrCodes = new Dictionary<int, WasteType>();

    private void Start()
    {
        qrCodes.Add(1,WasteType.Circle);
        qrCodes.Add(2, WasteType.Circle);
        qrCodes.Add(3, WasteType.Circle);
    }

    public bool HandleQR(int code)
    {
        if (qrCodes.ContainsKey(code))
        {
            qrCodes.Remove(code);
            //add to inventory
            return true;
        }
        else
        {
            return false;
        }
    }
}
