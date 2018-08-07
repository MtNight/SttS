using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanage : MonoBehaviour {

    public int scenenum;
    public Text load;

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
        if (scenenum == 0)
        {
            load.gameObject.SetActive(true);
        }
        else if (scenenum == 1)
        {
            load.gameObject.SetActive(false);
        }
        else if (scenenum == 2)
        {
            load.gameObject.SetActive(false);
        }
    }
}
