using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //move this
    public Sprite circle;
    public Sprite triangle;
    public Sprite rectangle;
    public Waste waste;

    public enum WasteType { Circle, Triangle, Rectangle };
    public Inventory inv;
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
        wasteList.Add(1, new Waste(WasteType.Circle, 1));
        wasteList.Add(2, new Waste(WasteType.Triangle, 2));
        wasteList.Add(3, new Waste(WasteType.Rectangle, 3));

        inv = Instantiate(inv, UIManager.Instance.transform, false);

    }

    public void HandleQR(string code)
    {
        int _code = int.Parse(code);
        if (wasteList.ContainsKey(_code))
        {
            foreach (Waste w in inv.list)
            { w.Destroy(); }
            inv.Add(wasteList[_code]);
            wasteList.Remove(_code);
            inv.LogList();
        }
    }
}
