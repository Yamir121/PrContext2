using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Button button;
    Item item;

    public void Awake()
    {
        button = GetComponentInChildren<Button>();
        Debug.Log(button);
    }

    public void AddItem (Item newItem)
    {
        button.onClick.AddListener(newItem.Select);
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot ()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
