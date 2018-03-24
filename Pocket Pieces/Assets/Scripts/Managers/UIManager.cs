using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public UIElement[] UIElements = { };
    public PopUp[] PopUps = { };
    [HideInInspector]
    public GameObject menu;
    [HideInInspector]
    public GameObject activeMenu;

    public static UIManager Instance { get { return _instance; } }
    private static UIManager _instance;
    [SerializeField]
    private UIElement activeElement;
    [SerializeField]
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
        
    }


    public void CreateScreen(int index)
    {
        UIElement preFab = UIElements[index];
        System.Type type = preFab.GetType();
        if (activeElement == null || activeElement.GetType() != type)
        {
            if (activeElement != null) { activeElement.Destroy(); }
            activeElement = Instantiate(preFab, gameObject.transform, false);
            activeElement.Setup();
        }

    }

    public void CreatePopUp(int index, string message)
    {
        PopUp preFab = PopUps[index];
        System.Type type = preFab.GetType();
        if (activePopUp == null || activePopUp.GetType() != type)
        {
            if (activePopUp != null) { activePopUp.Destroy(); }
            activePopUp = Instantiate(preFab, gameObject.transform, false);
            activePopUp.Setup();
            StartCoroutine(activePopUp.StartPopUp(message));
        }
    }

}