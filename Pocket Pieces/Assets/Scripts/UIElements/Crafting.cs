using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : UIElement
{

    public override void Setup()
    {
        Instantiate(UIManager.Instance.menu, UIManager.Instance.transform, false);
    }

    public override void Destroy()
    {
        Destroy()
        this.Destroy();
    }

}
