using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QRReader
{

    private WebCamTexture camTexture;
    private Rect screenRect;
    public string text = "";

    public QRReader()
    {}

    public void Create()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTexture = new WebCamTexture
        {
            requestedHeight = Screen.height,
            requestedWidth = Screen.width
        };
        if (camTexture != null)
        {
            camTexture.Play();
        }
    }

    public void Draw()
    {
        GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
    }

    public IEnumerator Read()
    {
        IBarcodeReader barcodeReader = new BarcodeReader();
        var result = barcodeReader.Decode(camTexture.GetPixels32(),camTexture.width, camTexture.height);
        if (result.Text != null)
        {
            Debug.Log("Not quite");
            text = result.Text;
            yield return null;
        }
        Debug.Log("Madeit");
        yield return new WaitForSeconds(2);
    }
}


