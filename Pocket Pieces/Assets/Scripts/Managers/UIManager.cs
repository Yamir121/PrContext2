using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public QRReader qrReader;
    public TextElement textElement;
<<<<<<< HEAD

    private UIElement activeElement;

=======
>>>>>>> 0cc0047f6651f57f5cf4180d9ea041ca73426d10
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
<<<<<<< HEAD
        CreateScreen(qrReader);
    }

    private void CreateScreen(UIElement preFab)
=======
        Create(qrReader);
    }

    private void Create(UIElement preFab)
>>>>>>> 0cc0047f6651f57f5cf4180d9ea041ca73426d10
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