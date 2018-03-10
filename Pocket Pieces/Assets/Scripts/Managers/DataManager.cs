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

        qrCodes.Add(1, WasteType.Circle);
        qrCodes.Add(2, WasteType.Circle);
        qrCodes.Add(3, WasteType.Circle);

        //qrCodes.add(4,WasteType.Triangle);  dus nummer 4= code van de qr code en wastetype geeft aan welk type het is



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
            qrCodes.Remove(code);

            //add to inventory
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
            timerText = "Time left: " + string.Format("{0:0}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void addToScore(int number)
    {
        score += number;

    }
}
