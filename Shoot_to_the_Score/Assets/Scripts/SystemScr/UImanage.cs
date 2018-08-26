using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanage : MonoBehaviour {

    public int scenenum= SceneManager.GetActiveScene().buildIndex;
    public Text load;
    public Text load2;
    public Text load3;
    public Text load4;

    void Start () {
        scenenum = 0;
		load.gameObject.SetActive(true);

        Screen.SetResolution(1600, 900, false);
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update () {
        if (SceneManager.GetActiveScene().name == "LoadingScene")
            {
            load.gameObject.SetActive(true);
            load2.gameObject.SetActive(false);
            load3.gameObject.SetActive(false);
            load4.gameObject.SetActive(false);
           
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            load.gameObject.SetActive(false);
            load2.gameObject.SetActive(false);
            load3.gameObject.SetActive(false);
            load4.gameObject.SetActive(false);
        }
        else //if (scenenum == 2)
        {
            load.gameObject.SetActive(false);
            load2.gameObject.SetActive(true);
            load3.gameObject.SetActive(true);
            load4.gameObject.SetActive(true);
        }
    }
}
