using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mainscreen : UIElement
{

    public Text timerText;
    public Text scoreText;
    public override void Setup()
    {
        //GameManager.dataManager.startTimer(900.0f);
        timerText.GetComponent<Text>();
        Instantiate(UIManager.Instance.menu, gameObject.transform, false);

    }

    private void Update()
    {
        timerText.text = GameManager.dataManager.timerText;
        scoreText.text = "Score: " + GameManager.dataManager.score;
    }
}
