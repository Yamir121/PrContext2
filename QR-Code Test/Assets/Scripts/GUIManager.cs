using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    QRReader reader = new QRReader();

    private void Start()
    {
        reader.Create();
        StartCoroutine(reader.Read());
    }

    private void OnGUI()
    {
        reader.Draw();
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "DECODED TEXT FROM QR: " + reader.text);
    }
}