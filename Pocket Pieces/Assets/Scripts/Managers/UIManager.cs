using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public QRReader qrReader;
    public TextPrompt textPrompt;

    public static UIManager Instance { get { return _instance; } }
    private static UIManager _instance;
    private UIElement activeElement;
    private PopUp activePopUp;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        CreateScreen(qrReader);
    }

    public void CreateScreen(UIElement preFab)
    {
        System.Type type = preFab.GetType();
        if (activeElement == null || activeElement.GetType() != type)
        {
            if (activeElement != null) { activeElement.Destroy(); }
            activeElement = Instantiate(qrReader, gameObject.transform, false);
            activeElement.Setup();
        }
    }

    public void CreatePopUp(PopUp preFab,string message)
    { System.Type type = preFab.GetType();
        if (activePopUp == null || activePopUp.GetType() != type)
        {
            if (activePopUp != null) { activePopUp.Destroy(); }
            activePopUp = Instantiate(preFab, gameObject.transform, false) as TextPrompt;
            activePopUp.Setup();
            StartCoroutine(activePopUp.StartPopUp(message));
        }
    }
}