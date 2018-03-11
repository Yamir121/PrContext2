using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript2 : MonoBehaviour
{

    #region Singleton

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback; //wordt getriggerd als er iets in de inventory veranderd

    public int space = 9;

    public List<Item> items = new List<Item>();

    public static InventoryScript2 instance;

    public bool Add(Item item)
    {

        if (items.Count >= space)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }


        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }


    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }


}
