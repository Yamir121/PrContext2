using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    public int score;


    Text scoreText;


    public enum WasteType { Circle, Triangle, Rectangle }; //door ,cylinder te schrijven bijvoorbeeld, voeg je nog een type toe

    private Dictionary<int, WasteType> qrCodes = new Dictionary<int, WasteType>(); //data base voor QR codes

    // alle variabelen voor de timer

    public Item circle;
    public Item triangle;
    public Item rectangle;
    public string timerText;
    float timeLeft = 900.0f;
    public bool stop = true;
    private float minutes;
    private float seconds;


    private void Start()
    {
        startTimer(timeLeft);
        scoreText = GetComponent<Text>();

        score = 0;

        //qrCodes.add(4,WasteType.Triangle);  dus nummer 4= code van de qr code en wastetype geeft aan welk type het is
        qrCodes.Add(1, WasteType.Circle);
        qrCodes.Add(2, WasteType.Circle);
        qrCodes.Add(3, WasteType.Circle);
        qrCodes.Add(4, WasteType.Rectangle);
        qrCodes.Add(5, WasteType.Rectangle);
        qrCodes.Add(6, WasteType.Rectangle);
        qrCodes.Add(7, WasteType.Triangle);
        qrCodes.Add(8, WasteType.Triangle);
        qrCodes.Add(9, WasteType.Triangle);






    }

    public void startTimer(float from)
    {
        stop = false;
        timeLeft = from;
        Update();
        StartCoroutine(updateCoroutine());
    }

    private void Update()
    {



        if (stop) return;
        timeLeft -= Time.deltaTime;

        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;
        if (seconds > 59) seconds = 59;
        if (minutes < 0)
        {
            stop = true;
            minutes = 0;
            seconds = 0;
        }


    }

    public bool HandleQR(int code)
    { //als QR code in de lijst zit, dan true
        if (qrCodes.ContainsKey(code))   //vraag object op die verbonden zit aan de key die code
        {
           

            AddToInventory(qrCodes[code]);
            qrCodes.Remove(code);

            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator updateCoroutine()
    {
        while (!stop)
        {
            timerText = string.Format("{0:0}:{1:00}", minutes, seconds);
            //timerText = "Time left: " + string.Format("{0:0}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void addToScore(int number)
    {
        score += number;

    }

    public void AddToInventory(WasteType wasteType)
    {
        Debug.Log("Adding item to inventory");
//        InventoryScript2.instance.Add(item);

        if (wasteType == WasteType.Circle)
        {
            InventoryScript2.instance.Add(circle);
        }


        else if (wasteType == WasteType.Rectangle)
        {
            InventoryScript2.instance.Add(rectangle);
        }


        else if (wasteType == WasteType.Triangle)
        {
            InventoryScript2.instance.Add(triangle);
        }
        else
        {
            Debug.Log("Cannot find wasteType");
        }
    }
}
