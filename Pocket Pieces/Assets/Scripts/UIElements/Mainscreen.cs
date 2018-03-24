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

        UIManager.Instance.activeMenu = Instantiate(UIManager.Instance.menu, UIManager.Instance.transform, false);

    }

    public override void Destroy()
    {
        Destroy(UIManager.Instance.activeMenu);
        Destroy(gameObject);
    }

    private void Update()
    {
        timerText.text = GameManager.dataManager.timerText;
        scoreText.text = "Score: " + GameManager.dataManager.score;
    }
}
