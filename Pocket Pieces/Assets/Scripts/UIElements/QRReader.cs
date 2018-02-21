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
        //draw inventory at top of screen

        webcamTexture = new WebCamTexture();
        rawimage = this.GetComponent<RawImage>();
        rawimage.texture = webcamTexture;
        rawimage.GetComponent<RectTransform>().sizeDelta = new Vector2((Screen.width * 1.333f), Screen.width);
        if (webcamTexture != null)
        {
            webcamTexture.Play();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && started == false)
        {
           
            //change this
            DataManager.Instance.HandleQR("2");
            DrawInventory();
            Debug.Log("Touch");
           // StartCoroutine(Read());
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
                DataManager.Instance.HandleQR(text);
                DrawInventory();
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

/*    private void AddObject(string text)
    {
        //temporarily posts to the screen
        UIElement textElement = Instantiate(UIManager.Instance.textElement, UIManager.Instance.transform, false);
        textElement.GetComponent<Text>().text = text;
    }
*/

    private void DrawInventory()
    {
        int index = 0;
        foreach (Waste w in DataManager.Instance.inv)
        {
            Waste newW = Instantiate(DataManager.Instance.waste, UIManager.Instance.transform, false);
            newW.type = w.type;
            float xPos = index * 2.3f;
            float yPos = index * 2.3f;
            newW.Draw(xPos, yPos);
            index++;
        }
    }

    public override void Destroy()
    {
        webcamTexture.Stop();
        Destroy(this.gameObject);
    }

}