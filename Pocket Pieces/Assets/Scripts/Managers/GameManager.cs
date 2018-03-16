using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static DataManager dataManager;

    public UIManager uiManager;

    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    //helemaal aan het begin, zodra het spel start. 1x van begin tot eind
    // als er al een instance van de game manager bestat, dan jezelf destroyen en anders jezelf aanmaken
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

        dataManager = GetComponent<DataManager>();

        if (UIManager.Instance == null)
        {
            //    Instantiate(uiManager);
        }
    }

    //start wordt 1x van begin tot eind uitgevoerd zodra het gameobject waar het script op zit wordt geinstantiate. 
    private void Start()
    {
        UIManager.Instance.CreateScreen(0);
        AudioManager.Instance.audioSources[0].Play();
        //UIManager.Instance.CreatePopUp(0, "Hello World");
    }

}
