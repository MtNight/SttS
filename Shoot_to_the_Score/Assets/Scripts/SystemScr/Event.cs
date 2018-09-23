using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {

    private GameObject EO;
    private GameObject EI;
    private GameObject cam;
    private bool[] arr;
    private int pre;
    public int cur;
    public int kill;
    public int add;

    void Start () {
        EO= Resources.Load("EnemyO") as GameObject;
        EI = Resources.Load("EnemyI") as GameObject;
        cam = GameObject.Find("Game Camera");
        arr = new bool[14];
        for (int i = 0; i < 14; i++)
        {
            arr[i] = false;
        }
        cur = 0;
        kill = 0;
        add = 0;
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
                case 0: {
                        if (kill >= 0) { arr[cur] = true; }
                        break; }
                case 1: {
                        if (kill >= 2) { arr[cur] = true; }
                        break; }
                case 2:
                    {
                        if (add == 0)
                        {
                            StartCoroutine(CreateEnemy(1.0f, EO, Vector3.right));
                        }
                        if (kill >= 2) { arr[cur] = true; }
                        break; }
                case 3:
                    {
                        if (add == 1)
                        {
                            StartCoroutine(CreateEnemy(1.0f, EO, Vector3.right));
                            //StartCoroutine(CreateEnemy(1.0f, EO, Vector3.left));
                        }
                        if (kill >= 3) { arr[cur] = true; }
                        break; }
                case 4:
                    {
                        if (add == 2)
                        {
                            StartCoroutine(CreateEnemy(4.0f, EO, Vector3.left));
                            StartCoroutine(CreateEnemy(5.0f, EO, Vector3.left));
                        }
                        if (kill >= 4) { arr[cur] = true; }
                        break; }
                case 5: {
                        if (kill >= 2) { arr[cur] = true; }
                        break; }
                case 6:
                    {
                        if (kill >= 1) { arr[cur] = true; }
                        break; }
                case 7:
                    {
                        if (add == 4)
                        {
                            StartCoroutine(CreateEnemy(1.0f, EI, Vector3.left));
                            StartCoroutine(CreateEnemy(2.0f, EI, Vector3.left));
                            StartCoroutine(CreateEnemy(4.0f, EI, Vector3.left));
                            //StartCoroutine(CreateEnemy(5.0f, EI, Vector3.left));
                        }
                        if (kill >= 3) { arr[cur] = true; }
                        break; }
                case 8:
                    {
                        if (add == 7)
                        {
                            StartCoroutine(CreateEnemy(2.0f, EO, Vector3.right));
                            //StartCoroutine(CreateEnemy(5.0f, EI, Vector3.right));
                            StartCoroutine(CreateEnemy(6.0f, EI, Vector3.right));
                        }
                        if (kill >= 4) { arr[cur] = true; }
                        break; }
                case 9:
                    {
                        if (add == 9)
                        {
                            StartCoroutine(CreateEnemy(7.0f, EI, Vector3.left));
                            StartCoroutine(CreateEnemy(8.0f, EI, Vector3.left));
                        }
                        if (kill >= 7) { arr[cur] = true; }
                        break; }
                case 10:
                    {
                        if (add == 11)
                        {
                            StartCoroutine(CreateEnemy(2.0f, EO, Vector3.right));
                            StartCoroutine(CreateEnemy(3.0f, EO, Vector3.right));
                            StartCoroutine(CreateEnemy(4.0f, EI, Vector3.left));
                            StartCoroutine(CreateEnemy(4.0f, EI, Vector3.left));
                        }
                        if (kill >= 6) { arr[cur] = true; }
                        break; }
                case 11:
                    {
                        if (add == 15)
                        {
                            StartCoroutine(CreateEnemy(4.0f, EO, Vector3.right));
                            //StartCoroutine(CreateEnemy(4.5f, EO, Vector3.right));
                            StartCoroutine(CreateEnemy(5.0f, EO, Vector3.right));
                        }
                        if (kill >= 7) { arr[cur] = true; }
                        break; }
                case 12:
                    {
                        if (add == 17)
                        {
                            StartCoroutine(CreateEnemy(6.0f, EO, Vector3.left));
                            //StartCoroutine(CreateEnemy(7.0f, EO, Vector3.left));
                            StartCoroutine(CreateEnemy(8.0f, EO, Vector3.left));
                            //StartCoroutine(CreateEnemy(8.5f, EO, Vector3.left));
                            StartCoroutine(CreateEnemy(9.0f, EO, Vector3.left));
                        }
                        if (kill >= 6) { arr[cur] = true; }
                        break; }
                case 13: {
                        if (kill >= 6) { arr[cur] = true; }
                        break; }
            }
            transform.position = cam.transform.position;
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }

        pre = cur;
    }

    IEnumerator CreateEnemy(float t, GameObject Enemy, Vector3 dir)
    {
        while (true)
        {
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
            yield break;
        }
    }
}
