using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRReader : UIElement
{
    private bool done = false;
    private WebCamTexture webcamTexture;
    private RawImage rawimage;

    public void Setup()
    {
        webcamTexture = new WebCamTexture();
        rawimage = this.GetComponent<RawImage>();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        if (webcamTexture != null)
        {
            webcamTexture.Play();
        }
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
                string text = result.Text;
                AddObject(text);
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

    public void AddObject(string text)
    {
        //temporarily posts to the screen
        UIElement textElement = Instantiate(UIManager.Instance.UIElements[1]);
        textElement.transform.SetParent(UIManager.Instance.gameObject.GetComponent<Transform>(), false);
        textElement.GetComponent<Text>().text = text;
    }

}