using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public enum WasteType { Circle, Triangle, Rectangle };
    public Inventory inv = new Inventory();
    private Dictionary<int, Waste> wasteList = new Dictionary<int, Waste>();

    public static DataManager Instance { get { return _instance; } }
    private static DataManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        wasteList.Add(1, new Waste(WasteType.Circle));
        wasteList.Add(2, new Waste(WasteType.Triangle));
        wasteList.Add(3, new Waste(WasteType.Rectangle));
    }

    public void HandleQR(string code)
    {
        int _code = int.Parse(code);
        if(wasteList.ContainsKey(_code))
        {            
            inv.Add(wasteList[_code]);
            wasteList.Remove(_code);
            inv.LogList();
        }
    }
}
