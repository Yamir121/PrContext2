using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRReader : UIElement
{
    private bool started = false;
    private WebCamTexture webcamTexture;
    private RawImage rawimage;

    public override void Setup()
    {
        webcamTexture = new WebCamTexture();
        rawimage = this.GetComponent<RawImage>();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        rawimage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height, Screen.width);
        if (webcamTexture != null)
        {
            webcamTexture.Play();
        }
    }
    
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && started == false)
        {
            Debug.Log("Touch");
            StartCoroutine(Read());
        }
    }

    private IEnumerator Read()
    {
        started = true;
        bool done = false;
        while (!done)
        {
            Debug.Log("Reading");
            IBarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(webcamTexture.GetPixels32(), webcamTexture.width, webcamTexture.height);
            if (result != null)
            {
                string text = result.Text;
                AddObject(text);
                Handheld.Vibrate();
                done = true;
                started = false;
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }

    private void AddObject(string text)
    {
        //temporarily posts to the screen
        UIElement textElement = Instantiate(UIManager.Instance.textElement, UIManager.Instance.transform,false);
        textElement.GetComponent<Text>().text = text;
    }

    public override void Destroy()
    {
        webcamTexture.Stop();
        UIManager.Instance.activeElements.Remove(this);
        Destroy(this.gameObject);
    }

}