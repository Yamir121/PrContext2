using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public UIElement qrreader;
    public UIElement textElement;
    public List<UIElement> UIElements;
    public static UIManager Instance { get { return _instance; } }
    private static UIManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

private void Start()
    {

        //adding to the list
        UIElements.Add(qrreader);
        UIElements.Add(textElement);
        
        //qrreader stuff
        QRReader reader = Instantiate(UIElements[0]) as QRReader;
        reader.transform.SetParent(gameObject.GetComponent<Transform>(),false);
        reader.GetComponent<QRReader>().Setup();
        StartCoroutine(reader.Read());
    }

}