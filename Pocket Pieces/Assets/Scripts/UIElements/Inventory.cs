using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : UIElement  
{



    public override void Setup()
    {
        Instantiate(UIManager.Instance.menu, gameObject.transform, false);
    }
}
