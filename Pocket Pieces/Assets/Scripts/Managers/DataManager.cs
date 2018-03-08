using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public enum WasteType { Circle, Triangle, Rectangle }; //door ,cylinder te schrijven bijvoorbeeld, voeg je nog een type toe

    private Dictionary<int, WasteType> qrCodes = new Dictionary<int, WasteType>(); //data base voor QR codes

    private void Start()
    {
        qrCodes.Add(1,WasteType.Circle);
        qrCodes.Add(2, WasteType.Circle);
        qrCodes.Add(3, WasteType.Circle);

        //qrCodes.add(4,WasteType.Triangle);  dus nummer 4= code van de qr code en wastetype geeft aan welk type het is
    }

    public bool HandleQR(int code) 
    { //als QR code in de lijst zit, dan true
        if (qrCodes.ContainsKey(code))   //vraag object op die verbonden zit aan de key die code
        {
            qrCodes.Remove(code);

            //add to inventory
            return true;
        }
        else
        {
            return false;
        }
    }
}
