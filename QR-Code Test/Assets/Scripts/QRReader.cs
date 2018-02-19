using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRReader : MonoBehaviour
{
    private bool done = false;
    private WebCamTexture webcamTexture;
    private RawImage rawimage;
    public string text = "";



    public QRReader()
    { }

    public void Create()
    {
        WebCamTexture webcamTexture = new WebCamTexture();
        rawimage = this.GetComponent<RawImage>();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        if (webcamTexture != null)
        {
            webcamTexture.Play();
        }
    }

    public void Draw()
    {
        //GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
    }

    public IEnumerator Read()
    {
        while (!done)
        {
            Debug.Log("Not yet");
            IBarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(webcamTexture.GetPixels32(), webcamTexture.width, webcamTexture.height);
            if (result != null)
            {
                Debug.Log("Not quite");
                text = result.Text;
                done = true;
                yield return null;
            }
            else
            {
                Debug.Log("Madeit");
                yield return new WaitForSeconds(1);
            }
        }
    }
}