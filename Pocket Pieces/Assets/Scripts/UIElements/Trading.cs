﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trading : UIElement
{

    public override void Setup()
    {
        Instantiate(UIManager.Instance.menu, UIManager.Instance.transform, false);
    }
}
