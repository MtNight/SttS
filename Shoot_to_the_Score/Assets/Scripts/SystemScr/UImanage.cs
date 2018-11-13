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
    public Slider bhp;
    public Text Die;
    public Button GtoM;
    public Image blackout;

    private GameObject i, j, k;

    void Start () {
        scenenum = 0;

        hp.minValue = 0;
        hp.maxValue = 500;
        hp.value = 500;

        bhp.minValue = 0;
        bhp.maxValue = 10000;
        bhp.value = 10000;

        load.gameObject.SetActive(true);
        main1.gameObject.SetActive(false);
        main2.gameObject.SetActive(false);
        main3.gameObject.SetActive(false);
        main4.gameObject.SetActive(false);
        game1.gameObject.SetActive(false);
        game2.gameObject.SetActive(false);
        game3.gameObject.SetActive(false);
        hp.gameObject.SetActive(false);
        bhp.gameObject.SetActive(false);
        Die.gameObject.SetActive(false);
        GtoM.gameObject.SetActive(false);
        blackout.gameObject.SetActive(false);

        Screen.SetResolution(1600, 900, false);
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        i = GameObject.Find("Event");
        k = GameObject.Find("pBeAttackRange");
        j = GameObject.Find("BOSS");
    }

    void Update () {
        if (scenenum == 0 && SceneManager.GetActiveScene().name == "LoadingScene")
            {
            load.gameObject.SetActive(true);
            game1.gameObject.SetActive(false);
            game2.gameObject.SetActive(false);
            game3.gameObject.SetActive(false);
            hp.gameObject.SetActive(false);
            bhp.gameObject.SetActive(false);
            main1.gameObject.SetActive(false);
            main2.gameObject.SetActive(false);
            main3.gameObject.SetActive(false);
            main4.gameObject.SetActive(false);
            Die.gameObject.SetActive(false);
            GtoM.gameObject.SetActive(false);
            blackout.gameObject.SetActive(false);

        }
        else if (scenenum == 1 && SceneManager.GetActiveScene().name == "MainMenu")
        {
            load.gameObject.SetActive(false);
            game1.gameObject.SetActive(false);
            game2.gameObject.SetActive(false);
            game3.gameObject.SetActive(false);
            hp.gameObject.SetActive(false);
            bhp.gameObject.SetActive(false);
            main1.gameObject.SetActive(true);
            main2.gameObject.SetActive(true);
            main3.gameObject.SetActive(true);
            main4.gameObject.SetActive(true);
            Die.gameObject.SetActive(false);
            GtoM.gameObject.SetActive(false);
            blackout.gameObject.SetActive(false);
        }
        else if (scenenum == 2 && SceneManager.GetActiveScene().name == "GameScene")
        {
            if (i == null || j == null || k == null)
            {
                i = GameObject.Find("Event");
                k = GameObject.Find("pBeAttackRange");
                j = GameObject.Find("BOSS");
            }
            if (GameObject.Find("Player") != null)
            {
                if (i.GetComponent<Event>().cur <= 1)
                {
                    game1.text = "Sejong Square";
                }
                else if (i.GetComponent<Event>().cur <= 13)
                {
                    game1.text = "Library";
                }
                else if (i.GetComponent<Event>().cur <= 17)
                {
                    game1.text = "The Tower";
                }
                game2.text = k.GetComponent<PlayerBattle>().mag + "/" + k.GetComponent<PlayerBattle>().maxMagazine;
                hp.value = k.GetComponent<PlayerBattle>().hp;
                bhp.value = j.GetComponent<Boss>().hp;

                load.gameObject.SetActive(false);
                game1.gameObject.SetActive(true);
                game2.gameObject.SetActive(true);
                game3.gameObject.SetActive(true);
                hp.gameObject.SetActive(true);
                if (i.GetComponent<Event>().cur == 17)
                {
                    bhp.gameObject.SetActive(true);
                }
                else
                {
                    bhp.gameObject.SetActive(false);
                }
                Die.gameObject.SetActive(false);
                GtoM.gameObject.SetActive(false);
                blackout.gameObject.SetActive(false);
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
                bhp.gameObject.SetActive(false);
                Die.gameObject.SetActive(true);
                GtoM.gameObject.SetActive(true);
                blackout.gameObject.SetActive(true);
                Vector3 tmp = GameObject.Find("Game Camera").transform.position;
                tmp.z = 1;
                blackout.transform.position = tmp;
                tmp = new Vector3(8, 8, 1);
                blackout.transform.localScale = tmp;
                main1.gameObject.SetActive(false);
                main2.gameObject.SetActive(false);
                main3.gameObject.SetActive(false);
                main4.gameObject.SetActive(false);
            }
        }
    }
}