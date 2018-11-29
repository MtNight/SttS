using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public int hp;
    private int maxhp;
    public int stat;   //-3=비활성화 -2,-1=이동 0=서있기 1=패턴1(일반) 2=패턴2(종이) 3=패턴3(빔프로) 4=패턴4(탈모빔) 5=패턴5(문제)
    private bool invin;
    private bool start;
    private bool shoot;

    private int patt;
    private int rand;
    private GameObject bullet;

    private GameObject player;
    private SpriteRenderer SR;
    private Collider2D COL;
    private Animator anim;
    private AudioSource audioSource;
    public AudioClip HitSound;
    public AudioClip BongSound;
    public AudioClip MarkerSound;
    public AudioClip PaperSound;
    public AudioClip SBeamSound;
    public AudioClip MoveSound;

    void Start () {
        maxhp = 15000;
        hp = 15000;
        stat = -3;
        invin = true;
        start = false;
        shoot = false;
        patt = Random.Range(0, 4);

        player = GameObject.Find("Player");
        SR = GetComponent<SpriteRenderer>();
        COL = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
                GameObject.Find("UImanager").GetComponent<UImanage>().boss = true;
            }
            StartCoroutine(Attack1());
            stat = 1;
            invin = false;
        }
        else if (stat == 1)
        {
            if (shoot == false)
            {
                switch (patt)
                {
                    case 0: 
                    case 1: StartCoroutine(Attack2(0)); break;  //각 코루틴에서 stat변경.
                    case 2: 
                    case 3: StartCoroutine(Attack3(0)); break;
                    case 4: 
                    case 5: StartCoroutine(Move(1)); break;
                }
            }
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
            GameObject.Find("Event").GetComponent<Event>().killcnt += 1;

            Destroy(this.gameObject);
        }
    }

    IEnumerator Attack1()   //평타
    {
        while (true)
        {
            shoot = true;
            float angle = 20.0f;
            for (int i = 10; i > 0; i--)
            {
                if (hp <= maxhp * i / 10.0f)
                {
                    yield return new WaitForSeconds(0.75f);
                    if (i % 2 == 1)
                    {
                        Shoot(new Vector3(transform.localScale.x, transform.localScale.x * Mathf.Tan(angle / 2 * Mathf.Deg2Rad), transform.localScale.x * angle / 2));
                        Shoot(new Vector3(transform.localScale.x, transform.localScale.x * Mathf.Tan(-angle / 2 * Mathf.Deg2Rad), transform.localScale.x * -angle / 2));
                    }
                    else
                    {
                        Shoot(new Vector3(transform.localScale.x, 0, 0));
                        Shoot(new Vector3(transform.localScale.x, transform.localScale.x * Mathf.Tan(angle * Mathf.Deg2Rad), transform.localScale.x * angle));
                        Shoot(new Vector3(transform.localScale.x, transform.localScale.x * Mathf.Tan(-angle * Mathf.Deg2Rad), transform.localScale.x * -angle));
                    }
                }
                else
                {
                    shoot = false;
                    yield break;
                }
            }
            shoot = false;
            yield break;
        }
    }
    IEnumerator Attack2(int t)   //종이
    {
        while (true)
        {
            stat = 2;
            yield return new WaitForSeconds(0.8f);
            anim.SetInteger("stat", 2);
            audioSource.PlayOneShot(BongSound);
            yield return new WaitForSeconds(0.8f);
            anim.SetInteger("stat", 0);
            int papernum = 14;
            if (hp < maxhp * 1 / 4)
            {
                papernum = 20;
            }
            else if (hp < maxhp * 1 / 2)
            {
                papernum = 18;
            }
            else if (hp < maxhp * 3 / 4)
            {
                papernum = 16;
            }
            for (int i = 0; i < papernum; i++)
            {
                Vector3 pos = new Vector3(0, -70, 5);
                pos.x = Random.Range(82, 98);
                rand = Random.Range(0, 3);
                switch (rand)
                {
                    case 0: bullet = Resources.Load("Paper1") as GameObject; break;
                    case 1: bullet = Resources.Load("Paper2") as GameObject; break;
                    case 2: bullet = Resources.Load("Paper3") as GameObject; break;
                }
                GameObject tmp = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));
                tmp.GetComponent<Paper>().atk = 10;
            }
            audioSource.PlayOneShot(PaperSound);
            if (t == 1)
            {
                stat = 4;
                yield break;
            }
            yield return new WaitForSeconds(3.0f);
            if (t == 0)
            {
                if (hp < maxhp / 2)
                {
                    patt = Random.Range(0, 6);
                }
                else
                {
                    patt = Random.Range(0, 5);
                }
                if (patt == 1) { patt = 2; }
                StartCoroutine(Move(0));
            }
            yield break;
        }
    }
    IEnumerator Attack3(int t)   //빔 프로젝터
    {
        while (true)
        {
            stat = 3;
            yield return new WaitForSeconds(0.8f);
            anim.SetInteger("stat", 2);
            audioSource.PlayOneShot(BongSound);
            yield return new WaitForSeconds(0.8f);
            anim.SetInteger("stat", 3);
            audioSource.PlayOneShot(BongSound);
            yield return new WaitForSeconds(0.8f);
            anim.SetInteger("stat", 0);
            yield return new WaitForSeconds(0.8f);
            if (hp < maxhp * 1 / 4)
            {
                bullet = Resources.Load("BeamPro") as GameObject;
                Instantiate(bullet, new Vector3(90 + 4 * transform.localScale.x, -66.5f, 0), Quaternion.Euler(0, 0, 0));
            }
            bullet = Resources.Load("BeamPro") as GameObject;
            Instantiate(bullet, new Vector3(90 - 4 * transform.localScale.x, -66.5f, 0), Quaternion.Euler(0, 0, 0));
            if (t == 1)
            {
                stat = 4;
                yield break;
            }
            yield return new WaitForSeconds(3.0f);
            if (t == 0)
            {
                if (hp < maxhp / 2)
                {
                    patt = Random.Range(0, 6);
                }
                else
                {
                    patt = Random.Range(0, 5);
                }
                if (patt == 2) { patt = 1; }
                StartCoroutine(Move(0));
            }
            yield break;
        }
    }
    IEnumerator Attack4()   //탈모빔
    {
        while (true)
        {
            patt = Random.Range(0, 5);
            stat = 4;
            int beamnum = 5;
            if (hp < maxhp / 2)
            {
                rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    beamnum += 3;
                }
                else if (rand == 1)
                {
                    StartCoroutine(Attack2(1));
                    yield return new WaitForSeconds(2.0f);
                }
                else
                {
                    StartCoroutine(Attack3(1));
                    yield return new WaitForSeconds(3.5f);
                }
            }
            anim.SetInteger("stat", 4);
            yield return new WaitForSeconds(1.0f);
            anim.SetInteger("stat", 5);
            if (hp < maxhp * 1 / 4)
            {
                beamnum += 3;
            }
            else if (hp < maxhp * 1 / 2)
            {
                beamnum += 3;
            }
            else if (hp < maxhp * 3 / 4)
            {
                beamnum += 3;
            }
            bullet = Resources.Load("TMBeam") as GameObject;
            for (int i = 0; i < beamnum; i++)
            {
                if (i % 2 == 0)
                {
                    rand = Random.Range(200, 340);
                }
                else
                {
                    rand = Random.Range(0, 360);
                }
                Instantiate(bullet, new Vector3(90, -75.75f, 4), Quaternion.Euler(0, 0, rand));
            }
            yield return new WaitForSeconds(5.0f);
            anim.SetInteger("stat", 0);
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(Move(0));
            yield break;
        }
    }

    IEnumerator Move(int t)
    {
        while (true)
        {
            stat = -1;
            anim.SetInteger("stat", -1);
            audioSource.PlayOneShot(MoveSound);
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
                transform.position = new Vector3(90, -76.75f, 6);
            }
            else if (t == 2)
            {
                //quiz
            }
            anim.SetInteger("stat", -2);
            SR.enabled = true;
            COL.enabled = true;
            audioSource.PlayOneShot(MoveSound);
            yield return new WaitForSeconds(1.2f);
            stat = -1;
            invin = false;
            yield return new WaitForSeconds(1.2f);
            if (t == 1)
            {
                StartCoroutine(Attack4());
            }
            else
            {
                anim.SetInteger("stat", 0);
                yield return new WaitForSeconds(1.0f);
                stat = 0;
            }
            yield break;
        }
    }

    private void Shoot(Vector3 dir)
    {
        rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0: bullet = Resources.Load("Marker1") as GameObject; break;
            case 1: bullet = Resources.Load("Marker2") as GameObject; break;
            case 2: bullet = Resources.Load("Marker3") as GameObject; break;
        }
        Vector3 pos = transform.position;
        pos.z -= 1;
        GameObject i = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));

        pos = i.transform.localScale;
        pos.x *= dir.x;
        i.transform.localScale = pos;

        Vector3 line = player.transform.position - transform.position;

        i.transform.Rotate(new Vector3(0, 0, dir.z + (Mathf.Atan(line.y / (float)line.x) * Mathf.Rad2Deg)));

        line.y += (float)((line.x * line.x + line.y * line.y) * dir.y) / (line.x - line.y * dir.y);
        dir.z = 0;
        line.z = 0;
        i.GetComponent<eBullet>().speed = 7.0f;
        i.GetComponent<eBullet>().dir = line.normalized;

        i.GetComponent<eBullet>().atk = 5;
        audioSource.PlayOneShot(MarkerSound);
    }
}
