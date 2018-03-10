using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public int screen;
    

    private Button button;
 


    // Use this for initialization
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        

        //   button.onClick.AddListener(TaskOnClick);

    }


    public void OnClick()
    {
       
        UIManager.Instance.CreateScreen(screen);
        
        //        Handheld.Vibrate();
    }
}
