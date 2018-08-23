using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour {

    private bool act;
    private bool tel;
    private GameObject player;

    void Start () {
        act = false;
        tel = GameObject.Find("Teleport1-1").GetComponent<Teleport>().use;
        player = GameObject.Find("Player");
	}
	
	void Update ()
    {
        if (act == false)
        {
            tel = GameObject.Find("Teleport1-1").GetComponent<Teleport>().use;
            if (tel == true)
            {
                player = GameObject.Find("Player");
                if (player.transform.position.x > 15.5f && player.transform.position.y > -74)
                {
                    Vector3 i = transform.position;
                    i.y -= 20;
                    transform.position = i;
                    act = true;
                }
            }
        }
	}
}
