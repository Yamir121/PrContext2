using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : UIElement
{

    public override void Setup()
    {
        UIManager.Instance.activeMenu = Instantiate(UIManager.Instance.menu, UIManager.Instance.transform, false);
    }

    public override void Destroy()
    {
        Destroy(UIManager.Instance.activeMenu);
        Destroy(gameObject);
    }
}
