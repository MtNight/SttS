using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public int hp;
    public int stat;   //-3=비활성화 -2,-1=이동 0=서있기 1=패턴1(일반) 2=패턴2(종이) 3=패턴3(빔프로) 4=패턴4(탈모빔) 5=패턴5(문제)
    private bool invin;
    private bool start;

    private int rand;

    private SpriteRenderer SR;
    private Collider2D COL;
    private Animator anim;
    private AudioSource audioSource;
    public AudioClip HitSound;

    void Start () {
        hp = 10000;
        stat = -3;
        invin = true;
        start = false;

        SR = GetComponent<SpriteRenderer>();
        COL = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        if (stat == -3)
        {
            gameObject.SetActive(false);
        }
        else if (stat == 0)
        {
            if (start == false)
            {
                start = true;
                //hp create
            }
            StartCoroutine(Move(0));
            invin = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pBullet")
        {
            if (invin == false)
            {
                hp -= other.gameObject.GetComponent<pBullet>().atk;
                Destroy(other.gameObject);
                audioSource.PlayOneShot(HitSound);
            }
        }

        if (hp <= 0)
        {
            GameObject.Find("Event").GetComponent<Event>().kill += 1;
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    IEnumerator Attack1()
    {
        while (true)
        {

        }
    }

    IEnumerator Move(int t)
    {
        while (true)
        {
            stat = -1;
            anim.SetInteger("stat", -1);
            yield return new WaitForSeconds(1.2f);
            stat = -2;
            invin = true;
            yield return new WaitForSeconds(1.2f);
            SR.enabled = false;
            COL.enabled = false;
            yield return new WaitForSeconds(1.2f);
            if (t == 0)
            {
                if (transform.position.x == 84)
                {
                    transform.position = new Vector3(96, -76.75f, 6);
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x == 96)
                {
                    transform.position = new Vector3(84, -76.75f, 6);
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    rand = Random.Range(0, 2);
                    if (rand == 0)
                    {
                        transform.position = new Vector3(96, -76.75f, 6);
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.position = new Vector3(84, -76.75f, 6);
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
            else if (t == 1)
            {
                //solar beam
            }
            else if (t == 2)
            {
                //quiz
            }
            anim.SetInteger("stat", -2);
            SR.enabled = true;
            COL.enabled = true;
            yield return new WaitForSeconds(1.2f);
            stat = -1;
            invin = false;
            yield return new WaitForSeconds(1.2f);
            anim.SetInteger("stat", 0);
            yield return new WaitForSeconds(10.0f);
            stat = 0;

            yield break;
        }
    }
}
