using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIElement : MonoBehaviour {

    //A UIElement needs an Setup function with all its setup.
    public abstract void Setup();

    public virtual void Destroy()
    {
        Destroy(this.gameObject);
    }

}
