using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public QRReader qrReader;
    public TextElement textElement;

    public static UIManager Instance { get { return _instance; } }
    private static UIManager _instance;
    private UIElement activeElement;

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

    private void CreateScreen(UIElement preFab)
    {
        System.Type type = preFab.GetType();
        if (activeElement == null || activeElement.GetType() != type)
        {
            if (activeElement != null) { activeElement.Destroy(); }
            activeElement = Instantiate(qrReader, gameObject.transform, false);
            activeElement.Setup();
        }
    }

}