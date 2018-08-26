using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanage : MonoBehaviour {

    public int scenenum;
    public Text load;
    public Text game1;
    public Text game2;
    public Text game3;
    public Slider hp;
    public Text main1;
    public Text main2;
    public Text main3;
    public Text main4;

    void Start () {
        scenenum = 0;
		load.gameObject.SetActive(true);
        game1.gameObject.SetActive(false);
        game2.gameObject.SetActive(false);
        game3.gameObject.SetActive(false);
        hp.gameObject.SetActive(false);
        main1.gameObject.SetActive(false);
        main2.gameObject.SetActive(false);
        main3.gameObject.SetActive(false);
        main4.gameObject.SetActive(false);

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
            game1.gameObject.SetActive(false);
            game2.gameObject.SetActive(false);
            game3.gameObject.SetActive(false);
            hp.gameObject.SetActive(false);
            main1.gameObject.SetActive(false);
            main2.gameObject.SetActive(false);
            main3.gameObject.SetActive(false);
            main4.gameObject.SetActive(false);

        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            load.gameObject.SetActive(false);
            game1.gameObject.SetActive(false);
            game2.gameObject.SetActive(false);
            game3.gameObject.SetActive(false);
            hp.gameObject.SetActive(false);
            main1.gameObject.SetActive(true);
            main2.gameObject.SetActive(true);
            main3.gameObject.SetActive(true);
            main4.gameObject.SetActive(true);
        }
        else if (scenenum == 2)
        {
            load.gameObject.SetActive(false);
            game1.gameObject.SetActive(true);
            game2.gameObject.SetActive(true);
            game3.gameObject.SetActive(true);
            hp.gameObject.SetActive(true);
            main1.gameObject.SetActive(false);
            main2.gameObject.SetActive(false);
            main3.gameObject.SetActive(false);
            main4.gameObject.SetActive(false);
        }
    }
}
