using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public int score;
    Text scoreText;

    public List<Waste> allWasteTypes = new List<Waste>();
    public Waste[] selectedWaste = new Waste[3];

    private Dictionary<int, Waste> qrCodes = new Dictionary<int, Waste>();
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

        for (int i = 0; i < allWasteTypes.Count;i++)
        {
            Debug.Log(allWasteTypes[i]);
            Waste w = allWasteTypes[i];
            qrCodes.Add((i+1),w);
        }

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
        if (qrCodes.ContainsKey(code))
        {
            AddToInventory(qrCodes[code]);
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

    /* SCORE STUFF
    public void addToScore(int number)
    {
        score += number;

    }
    */

    public void AddToInventory(Waste waste)
    {
        Debug.Log("Adding item to inventory");
        GameManager.Instance.inventoryManager.Add(waste);

    }

    public bool EmptySelectedWaste()
    {
        for (int i = 0; i < selectedWaste.Length;  i++)
        {
            selectedWaste[i] = null;
            return true;
        }
        return false;
    }


    public bool SelectWaste(Waste waste)
    {
        for (int i = 0; i < selectedWaste.Length; i++)
        {
            if (selectedWaste[i] == null)
            {
                selectedWaste[i] = waste;
                return true;
            }
        }
        return false;
    }

    public bool DeselectWaste(Waste waste)
    {
        for (int i = 0; i < selectedWaste.Length; i++)
        {
            if (selectedWaste[i] == waste)
            {
                selectedWaste[i] = null;
                return true;
            }
        }
        return false;
    }

}
