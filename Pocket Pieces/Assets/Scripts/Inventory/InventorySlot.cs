using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Button button;
    public Image selectedImage;
    Item item;

    public void Awake()
    {
        button = GetComponentInChildren<Button>();
        if(selectedImage!=null)
        {
            selectedImage.GetComponent<Transform>().SetAsLastSibling();
            selectedImage.enabled = false;
        }
    }

    public void AddItem(Item newItem)
    {
        button.onClick.AddListener(newItem.Select);
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void Selected()
    {
        if (item == null)
        {
            return;
        }
        Waste[] selected = GameManager.dataManager.selectedWaste;
        for (int i = 0; i < selected.Length; i++)
        {
            if (selected[i] == (item))
            {
                selectedImage.enabled = true;
                return;
            }
            else
            {
                selectedImage.enabled = false;
            }          
        }
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
