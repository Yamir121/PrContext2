using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PopUp : UIElement {

    public override abstract void Setup();

    public abstract IEnumerator StartPopUp(string text);
}
