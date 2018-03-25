using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseBlueprint : PopUp
{
    public Image thing;
    public Text thingName;
    Thing result;

    public override void Setup()
    {

    }

    public override IEnumerator StartPopUp(string _text)
    {
        gameObject.transform.GetChild(1).GetComponent<Text>().text = _text;
        yield return null;
    }

    public void AddThing(Thing _result)
    {
        thing.sprite = _result.icon;
        thingName.text = _result.name + _result.functionLvl;
        result = _result;
    }

    public void Build()
    {
        Debug.Log("Build");
    }

}
