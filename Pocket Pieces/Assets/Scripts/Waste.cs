using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waste : Item {


    public DataManager.WasteType type;
    private RectTransform imgTransform;
    private Image img;

    //change this
    public Waste(DataManager.WasteType t)
    {
        this.type = t;
    }
    public DataManager.WasteType GetWasteType()
    {
        return this.type;
    }

    public void Draw(float xPos, float yPos)
    {
        Debug.Log(this.type + gameObject.name);
        if (this.type == DataManager.WasteType.Circle) { GetComponent<Image>().sprite = DataManager.Instance.circle; }
        else if (this.type == DataManager.WasteType.Triangle) { GetComponent<Image>().sprite = DataManager.Instance.triangle; }
        else if (this.type == DataManager.WasteType.Rectangle) { GetComponent<Image>().sprite = DataManager.Instance.rectangle; }
        var rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchorMax = new Vector2(xPos,yPos);
        rectTransform.anchorMin = new Vector2((xPos*0.5f), (yPos*0.5f));
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.sizeDelta = new Vector2(100, 100);
    }

}
