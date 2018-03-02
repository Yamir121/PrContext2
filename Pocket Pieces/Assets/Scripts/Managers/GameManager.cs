using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static DataManager dataManager;

    public UIManager uiManager;

    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

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
            Instantiate(uiManager);
        }
    }

    private void Start()
    {
        UIManager.Instance.CreateScreen(0);
    }

}
