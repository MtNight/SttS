using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public int hp;
    public int stat;   //-3=비활성화 -2,-1=이동 0=서있기 1=패턴1(일반) 2=패턴2(종이) 3=패턴3(빔프로) 4=패턴4(탈모빔) 5=패턴5(문제)
    private bool invin;

    private SpriteRenderer SR;

	void Start () {
        gameObject.SetActive(false);
        hp = 1000;
        stat = -3;
        invin = true;
	}
	
	void Update () {
        if (stat == -3) {
            stat = 0;
            invin = false;
        }
        hp++;
	}

    IEnumerator Attack1()
    {
        while (true)
        {

        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            stat = -1;
            yield return new WaitForSeconds(1.0f);
            stat = -2;
            yield return new WaitForSeconds(1.0f);
            SR.enabled = false;
            invin = true;
            //move
            yield return new WaitForSeconds(2.0f);
            stat = 0;
            SR.enabled = true;
            invin = false;
            yield break;
        }
    }
}
