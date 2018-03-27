using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrompt : PopUp {

    private Text textComp;


    public override void Setup()
    {
        textComp = gameObject.GetComponent<Text>();
	}

    public override IEnumerator StartPopUp(string message)
    {
        textComp.text = message;
        yield return new WaitForSeconds(3);
        textComp.text = "";
        this.Destroy();
        yield return null;
    }

}
