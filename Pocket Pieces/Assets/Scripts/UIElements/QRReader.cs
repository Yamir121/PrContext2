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

        webcamTexture = new WebCamTexture(); //functie van unity. pakt data van webcam op device en maakt er een texture van
        rawimage = this.GetComponent<RawImage>(); 
        rawimage.texture = webcamTexture;
        rawimage.GetComponent<RectTransform>().sizeDelta = new Vector2((Screen.width * 1.333f), Screen.width); //height en width (vector2). aan width voegt hij een constante toe om width&height goed te houden
        if (webcamTexture != null) //start webcamtexture
        {
            webcamTexture.Play();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && started == false) //tappen
        {
           Debug.Log("Touch");
           StartCoroutine(Read()); //functie die gestopt kan worden of kan pauzeren
        }
    }

    private IEnumerator Read()  //dit is de coroutine
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
            if (result != null && int.TryParse(result.Text,out code)) //tryparse barcode geeft je een string, en zet deze om tot integer. als dat lukt geeft hij een true
            {
                //Let the DataManager handle the QR, only if the Manager succeeds, the QRReader stops reading. 
                if (GameManager.dataManager.HandleQR(code))
                {
                    Handheld.Vibrate();
                    UIManager.Instance.CreatePopUp(1, "Item Found!");
                    
                    done = true;
                    started = false;                 
                    yield return null;  //sluit coroutine af
                }
                else // als code niet meer in de database zit(code al gescand), dan:
                {
                    Handheld.Vibrate();
                    UIManager.Instance.CreatePopUp(0, "Item Already Scanned!");
                    yield return new WaitForSeconds(2);
                }
            }
            else //als hij geen int terug krijgt of geen resultaat is, dan:
            {
                yield return new WaitForSeconds(1); //je moet in een coroutine altijd iets returnen. in dit geval een wachttijd. voorkomt lagg
            }
        }
    }

    public override void Destroy()
    {
        webcamTexture.Stop(); //zet cam uit. wordt automatisch door ui manager geroepen
        Destroy(this.gameObject);
    }

}