using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waste : Item
{


    public DataManager.WasteType type;
    public int id;
    private RectTransform imgTransform;
    private Image img;

    //change this
    public Waste(DataManager.WasteType t, int id)
    {
        this.type = t;
        this.id = id;
    }
    public DataManager.WasteType GetWasteType()
    {
        return this.type;
    }

    public void Draw(float xPos, float yPos)
    {
        Debug.Log(this.type + gameObject.name);
        if (this.type == DataManager.WasteType.Circle) { gameObject.GetComponent<Image>().sprite = DataManager.Instance.circle; }
        else if (this.type == DataManager.WasteType.Triangle) { gameObject.GetComponent<Image>().sprite = DataManager.Instance.triangle; }
        else if (this.type == DataManager.WasteType.Rectangle) { gameObject.GetComponent<Image>().sprite = DataManager.Instance.rectangle; }
        var rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchorMax = new Vector2(xPos, yPos);
        rectTransform.anchorMin = new Vector2((xPos * 0f), (yPos * 0f));
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.sizeDelta = new Vector2(130, 130);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
