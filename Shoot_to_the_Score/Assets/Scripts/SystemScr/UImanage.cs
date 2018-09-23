using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanage : MonoBehaviour {

    public int scenenum;
    public Text load;
    public Text main1;
    public Text main2;
    public Text main3;
    public Text main4;
    public Text game1;
    public Text game2;
    public Text game3;
    public Slider hp;
    public Text Die;
    public Button GtoM;
    public Image blackout;

    void Start () {
        scenenum = 0;

        hp.minValue = 0;
        hp.maxValue = 500;
        hp.value = 500;

        load.gameObject.SetActive(true);
        main1.gameObject.SetActive(false);
        main2.gameObject.SetActive(false);
        main3.gameObject.SetActive(false);
        main4.gameObject.SetActive(false);
        game1.gameObject.SetActive(false);
        game2.gameObject.SetActive(false);
        game3.gameObject.SetActive(false);
        hp.gameObject.SetActive(false);
        Die.gameObject.SetActive(false);
        GtoM.gameObject.SetActive(false);
        blackout.gameObject.SetActive(false);

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
            Die.gameObject.SetActive(false);
            GtoM.gameObject.SetActive(false);
            blackout.gameObject.SetActive(false);

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
            Die.gameObject.SetActive(false);
            GtoM.gameObject.SetActive(false);
            blackout.gameObject.SetActive(false);
        }
        else if (scenenum == 2)
        {
            if (GameObject.Find("Player") != null)
            {
                GameObject i = GameObject.Find("Event");
                if (i.GetComponent<Event>().cur <= 1)
                {
                    game1.text = "±¤Àå";
                }
                else if (i.GetComponent<Event>().cur <= 13)
                {
                    game2.text = "µ¿Ãµ°ü";
                }
                i = GameObject.Find("pBeAttackRange");
                game2.text = i.GetComponent<PlayerBattle>().mag + "/" + i.GetComponent<PlayerBattle>().maxMagazine;
                hp.value = i.GetComponent<PlayerBattle>().hp;

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
            else
            {
                load.gameObject.SetActive(false);
                game1.gameObject.SetActive(false);
                game2.gameObject.SetActive(false);
                game3.gameObject.SetActive(false);
                hp.gameObject.SetActive(false);
                main1.gameObject.SetActive(false);
                main2.gameObject.SetActive(false);
                main3.gameObject.SetActive(false);
                main4.gameObject.SetActive(false);
                Die.gameObject.SetActive(true);
                GtoM.gameObject.SetActive(true);
                blackout.gameObject.SetActive(true);
                Vector3 i = GameObject.Find("Game Camera").transform.position;
                i.z = 1;
                blackout.transform.position = i;
                i = new Vector3(8, 8, 1);
                blackout.transform.localScale = i;
            }
        }
    }
}