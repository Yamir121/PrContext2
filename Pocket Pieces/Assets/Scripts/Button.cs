using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Button : MonoBehaviour {

   private Button button;
    public int screen;

	// Use this for initialization
	void Start () {
        button = gameObject.GetComponent<Button>();
     //   button.onClick.AddListener(TaskOnClick);

	}
	
	
    public void OnClick()
    {
        UIManager.Instance.CreateScreen(screen);
    }
}
