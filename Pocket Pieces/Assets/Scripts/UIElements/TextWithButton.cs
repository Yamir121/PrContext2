using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWithButton : PopUp {
    public override void Setup()
    {

    }

    public override IEnumerator StartPopUp(string _text)
    {
        gameObject.transform.GetChild(0).GetComponent<Text>().text = _text;
        yield return null;
    }

    public void OnClick()
    {
        
        this.Destroy();
    }
}
