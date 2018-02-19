using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public UIElement qrreader;
    public List<UIElement> UIElements;

    private void Start()
    {
        UIElements.Add(qrreader);
        QRReader reader = Instantiate(UIElements[0]) as QRReader;
        reader.transform.SetParent(gameObject.GetComponent<Transform>(),false);
        reader.GetComponent<QRReader>().Setup();
        StartCoroutine(reader.Read());
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "DECODED TEXT FROM QR: " + qrreader.GetComponent<QRReader>().text);
    }
}