using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    public QRReader reader;

    private void Start()
    {
        StartCoroutine(reader.Read());
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "DECODED TEXT FROM QR: " + reader.text);
    }
}