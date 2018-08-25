using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {

    private GameObject cam;
    private bool[] arr;
    private int pre;
    public int cur;
    public int kill;

    void Start () {
        cam = GameObject.Find("Game Camera");
        arr = new bool[14];
        for (int i = 0; i < 14; i++)
        {
            arr[i] = false;
        }
        cur = 0;
        kill = 0;
	}
	
	void Update ()
    {
        cam = GameObject.Find("Game Camera");
        if (cam.transform.position.x == 10 && cam.transform.position.y == -42.5f) { cur = 0; }
        else if (cam.transform.position.x == 30 && cam.transform.position.y == -42.5f) { cur = 1; }
        else if (cam.transform.position.x == 10 && cam.transform.position.y == -110) { cur = 2; }
        else if (cam.transform.position.x == 30 && cam.transform.position.y == -110) { cur = 3; }
        else if (cam.transform.position.x == 50 && cam.transform.position.y == -110) { cur = 4; }
        else if (cam.transform.position.x == 10 && cam.transform.position.y == -76.25f) { cur = 5; }
        else if (cam.transform.position.x == 10 && cam.transform.position.y == -65) { cur = 6; }
        else if (cam.transform.position.x == 30 && cam.transform.position.y == -98.75f) { cur = 7; }
        else if (cam.transform.position.x == 10 && cam.transform.position.y == -98.75f) { cur = 8; }
        else if (cam.transform.position.x == 50 && cam.transform.position.y == -98.75f) { cur = 9; }
        else if (cam.transform.position.x == 30 && cam.transform.position.y == -87.5f) { cur = 10; }
        else if (cam.transform.position.x == 10 && cam.transform.position.y == -87.5f) { cur = 11; }
        else if (cam.transform.position.x == 50 && cam.transform.position.y == -87.5f) { cur = 12; }
        else if (cam.transform.position.x == 50 && cam.transform.position.y == -76.25f) { cur = 13; }

        if (pre != cur)
        {
            kill = 0;
        }

        if (arr[cur] == false)
        {
            switch (cur)
            {
                case 0: { if (kill >= 0) { arr[cur] = true; } break; }
                case 1: { if (kill >= 2) { arr[cur] = true; } break; }
                case 2: { if (kill >= 1) { arr[cur] = true; } break; }
                case 3: { if (kill >= 2) { arr[cur] = true; } break; }
                case 4: { if (kill >= 1) { arr[cur] = true; } break; }
                case 5: { if (kill >= 2) { arr[cur] = true; } break; }
                case 6: { if (kill >= 1) { arr[cur] = true; } break; }
                case 7: { if (kill >= 0) { arr[cur] = true; } break; }
                case 8: { if (kill >= 2) { arr[cur] = true; } break; }
                case 9: { if (kill >= 3) { arr[cur] = true; } break; }
                case 10: { if (kill >= 0) { arr[cur] = true; } break; }
                case 11: { if (kill >= 0) { arr[cur] = true; } break; }
                case 12: { if (kill >= 4) { arr[cur] = true; } break; }
                case 13: { if (kill >= 2) { arr[cur] = true; } break; }
            }
            transform.position = cam.transform.position;
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }

        pre = cur;
    }
}
