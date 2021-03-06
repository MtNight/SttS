﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public int tnum;
    public bool use;
    public bool active;
    private GameObject evn;

	void Start () {
        use = false;
        if (transform.position.x == 36 && transform.position.y == -20.5)
        {
            tnum = 0;
            active = true;
        }
        else if (transform.position.x == 39.5f && transform.position.y == -40.5f)
        {
            tnum = 1;
            active = true;
        }
        else if (transform.position.x == 26.2f && transform.position.y == -113.0f)
        {
            tnum = 2;
            active = false;
        }
        else if (transform.position.x == 5.3f && transform.position.y == -68.0f)
        {
            tnum = 3;
            active = true;
        }
        else if (transform.position.x == 23.3f && transform.position.y == -101.75f)
        {
            tnum = 4;
            active = false;
        }
        else if (transform.position.x == 50.1f && transform.position.y == -90.5f)
        {
            tnum = 5;
            active = false;
        }
        else if (transform.position.x == 41.0f && transform.position.y == -78.5f)
        {
            tnum = 6;
            active = true;
        }
        else if (transform.position.x == 1 && transform.position.y == -44.5f)
        {
            tnum = 7;
            active = true;
        }
        evn = GameObject.Find("Event");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Range")
        {
            if (other.transform.parent.gameObject.tag == "Player")
            {
                if (active == true)
                {
                    switch (tnum)
                    {
                        case 0: other.transform.parent.gameObject.transform.position = new Vector3(1, -112, 5); use = true; break;//test
                        case 1: if (evn.GetComponent<Event>().killcnt >= 2) { other.transform.parent.gameObject.transform.position = new Vector3(1, -112, 5); use = true; } break;   //0-2
                        case 2: other.transform.parent.gameObject.transform.position = new Vector3(6, -78.9f, 5); use = true; break;   //1-2
                        case 3: if (evn.GetComponent<Event>().killcnt >= 14) { other.transform.parent.gameObject.transform.position = new Vector3(36, -101f, 5); use = true; } break;   //f-2
                        case 4: other.transform.parent.gameObject.transform.position = new Vector3(23, -90.5f, 5); use = true; break;   //1-6
                        case 5: if (evn.GetComponent<Event>().killcnt >= 47) { other.transform.parent.gameObject.transform.position = new Vector3(50, -80.3f, 5); use = true; } break;   //1-11
                        case 6: if (evn.GetComponent<Event>().killcnt >= 53) { other.transform.parent.gameObject.transform.position = new Vector3(98, -112f, 5); use = true; } break;   //1-f
                        case 7: other.transform.parent.gameObject.transform.position = new Vector3(98, -112f, 5); use = true; break;   //tset
                    }
                }
            }
        }
    }
}
