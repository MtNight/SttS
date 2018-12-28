using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {

    private GameObject EO;
    private GameObject EI;
    private GameObject cam;
    private bool[] arr;
    public int cur;
    public int killcnt;
    public int add;
    private int create;

    void Start () {
        EO= Resources.Load("EnemyO") as GameObject;
        EI = Resources.Load("EnemyI") as GameObject;
        cam = GameObject.Find("Game Camera");
        arr = new bool[20];
        for (int i = 0; i < 14; i++)
        {
            arr[i] = false;
        }
        cur = 0;
        killcnt = 0;
        add = 0;
        create = 0;

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
        else if (cam.transform.position.x == 90 && cam.transform.position.y == -110) { cur = 14; }
        else if (cam.transform.position.x == 90 && cam.transform.position.y == -98.75f) { cur = 15; }
        else if (cam.transform.position.x == 90 && cam.transform.position.y == -87.5f) { cur = 16; }
        else if (cam.transform.position.x == 90 && cam.transform.position.y == -76.25f) { cur = 17; }
        else { cur = 18; }

        if (arr[cur] == false)
        {
            switch (cur)
            {
                case 0:
                    {
                        if (killcnt >= 0) { arr[cur] = true; }   //0
                        break;
                    }
                case 1:
                    {
                        if (killcnt >= 2) { arr[cur] = true; }   //2
                        break;
                    }
                case 2:
                    {
                        if (add == 0)
                        {
                            StartCoroutine(CreateEnemy(1.0f, EO, Vector3.right));
                        }
                        if (killcnt >= 4) { arr[cur] = true; }   //4
                        break;
                    }
                case 3:
                    {
                        if (add == 1)
                        {
                            StartCoroutine(CreateEnemy(1.0f, EO, Vector3.right));
                        }
                        if (killcnt >= 7) { arr[cur] = true; }   //7
                        break;
                    }
                case 4:
                    {
                        if (add == 2)
                        {
                            StartCoroutine(CreateEnemy(4.0f, EO, Vector3.left));
                            StartCoroutine(CreateEnemy(5.0f, EO, Vector3.left));
                        }
                        if (killcnt >= 11) { arr[cur] = true; }   //11
                        break;
                    }
                case 5:
                    {
                        if (killcnt >= 13) { arr[cur] = true; }   //13
                        break;
                    }
                case 6:
                    {
                        if (killcnt >= 14) { arr[cur] = true; }   //14
                        break;
                    }
                case 7:
                    {
                        if (add == 4)
                        {
                            StartCoroutine(CreateEnemy(1.0f, EI, Vector3.left));
                            StartCoroutine(CreateEnemy(2.0f, EI, Vector3.left));
                            StartCoroutine(CreateEnemy(4.0f, EI, Vector3.left));
                        }
                        if (killcnt >= 17) { arr[cur] = true; }   //17
                        break;
                    }
                case 8:
                    {
                        if (add == 7)
                        {
                            StartCoroutine(CreateEnemy(2.0f, EO, Vector3.right));
                            StartCoroutine(CreateEnemy(6.0f, EI, Vector3.right));
                        }
                        if (killcnt >= 21) { arr[cur] = true; }   //21
                        break;
                    }
                case 9:
                    {
                        if (add == 9)
                        {
                            StartCoroutine(CreateEnemy(7.0f, EI, Vector3.left));
                            StartCoroutine(CreateEnemy(8.0f, EI, Vector3.left));
                        }
                        if (killcnt >= 28) { arr[cur] = true; }   //28
                        break;
                    }
                case 10:
                    {
                        if (add == 11)
                        {
                            StartCoroutine(CreateEnemy(2.0f, EO, Vector3.right));
                            StartCoroutine(CreateEnemy(3.0f, EO, Vector3.right));
                            StartCoroutine(CreateEnemy(4.0f, EI, Vector3.left));
                            StartCoroutine(CreateEnemy(4.5f, EI, Vector3.left));
                        }
                        if (killcnt >= 34) { arr[cur] = true; }   //34
                        break;
                    }
                case 11:
                    {
                        if (add == 15)
                        {
                            StartCoroutine(CreateEnemy(4.0f, EO, Vector3.right));
                            StartCoroutine(CreateEnemy(5.0f, EO, Vector3.right));
                        }
                        if (killcnt >= 41) { arr[cur] = true; }   //41
                        break;
                    }
                case 12:
                    {
                        if (add == 17)
                        {
                            StartCoroutine(CreateEnemy(3.0f, EO, Vector3.left));
                            StartCoroutine(CreateEnemy(5.0f, EO, Vector3.left));
                            StartCoroutine(CreateEnemy(7.0f, EO, Vector3.left));
                        }
                        if (killcnt >= 47) { arr[cur] = true; }   //47
                        break;
                    }
                case 13:
                    {
                        if (killcnt >= 53) { arr[cur] = true; }   //53
                        break;
                    }
            }
            transform.position = cam.transform.position;
        }
        else if (create == 0)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    IEnumerator CreateEnemy(float t, GameObject Enemy, Vector3 dir)
    {
        while (true)
        {
            create += 1;
            int tmp = add;
            if (add != -1)
            {
                add = -1;
            }
            yield return new WaitForSeconds(t);
            Vector3 pos = transform.position + (dir * 11);
            pos.y -= 3;
            pos.z = 5;
            GameObject i = Instantiate(Enemy, pos, Quaternion.Euler(0, 0, 0));
            i.GetComponent<EnemyMove>().move = -1;
            if (tmp != -1)
            {
                add = tmp + 1;
            }
            else
            {
                add += 1;
            }
            create -= 1;
            yield break;
        }
    }
}
