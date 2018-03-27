using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Succes : PopUp
{
    public Image thing;
    public Text thingName;
    public BluePrint bluePrint;

    public override void Setup()
    {

    }

    public override IEnumerator StartPopUp(string _text)
    {
        gameObject.transform.GetChild(1).GetComponent<Text>().text += _text;
        yield return null;
    }

    public void AddBlueprint(BluePrint _bluePrint)
    {
        bluePrint = _bluePrint;
        thing.sprite = _bluePrint.result.icon;
        thingName.text = _bluePrint.result.name + _bluePrint.result.functionLvl;

    }
}
