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
            int code;
            //Checks if there is a result of the scan and if it is an int.
            if (result != null && int.TryParse(result.Text,out code))
            {
                //Let the DataManager handle the QR, only if the Manager succeeds, the QRReader stops reading. 
                if (DataManager.Instance.HandleQR(code))
                {
                    Handheld.Vibrate();
                    //popup: item added!
                    done = true;
                    started = false;                 
                    yield return null;
                }
                else
                {
                    Handheld.Vibrate();
                    //popup: item already scanned or wrong qrcode
                    yield return new WaitForSeconds(1);
                }
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }

    public override void Destroy()
    {
        webcamTexture.Stop();
        Destroy(this.gameObject);
    }

}