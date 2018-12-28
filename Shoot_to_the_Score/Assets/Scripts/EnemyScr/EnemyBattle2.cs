using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle2 : MonoBehaviour
{

    private bool summon;
    public bool fire;
    public bool cool;
    private bool dead;
    public int hp;
    public int attack;
    public Vector3 dir;
    public Vector3 pos;
    public GameObject bullet;
    public GameObject cam;
    private AudioSource audioSource;
    public AudioClip ShootSound;
    public AudioClip HitSound;
    private GameObject Fre;

    void Start()
    {
        summon = false;
        fire = false;
        cool = false;
        dead = false;
        hp = 120;
        dir = transform.parent.gameObject.GetComponent<EnemyMove>().dir;
        bullet = Resources.Load("PlayeBullet") as GameObject;
        cam = GameObject.Find("Game Camera");
        audioSource = GetComponent<AudioSource>();
        Fre = Resources.Load("EnemyI") as GameObject;
    }

    void Update()
    {
        cam = GameObject.Find("Game Camera");
        if (Mathf.Abs(cam.transform.position.x - transform.position.x) < 10 && Mathf.Abs(cam.transform.position.y - transform.position.y) < 5.625f)
        {
            attack = transform.parent.gameObject.GetComponent<EnemyMove>().move;
            if (attack == 0 && cool == false)
            {
                if (summon == false)
                {
                    summon = true;
                    Summon();
                }
                cool = true;
                StartCoroutine("Attack");
            }
        }
    }
    private void Shoot()
    {
        if (Mathf.Abs(cam.transform.position.x - transform.position.x) < 10 && Mathf.Abs(cam.transform.position.y - transform.position.y) < 5.625f)
        {
            dir = transform.parent.gameObject.GetComponent<EnemyMove>().dir;
            pos = transform.parent.gameObject.GetComponent<EnemyMove>().dir / 5.0f;
            pos += transform.position;
            pos.x += 0.1f;
            pos.y += 0.05f;
            pos.z = 6;
            GameObject i = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));
            i.GetComponent<eBullet>().dir = dir;
            i.GetComponent<eBullet>().atk = 15;
            audioSource.PlayOneShot(ShootSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pBullet")
        {
            hp -= other.gameObject.GetComponent<pBullet>().atk;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(HitSound);
        }
        
        if (hp <= 0 && dead == false)
        {
            dead = true;
            GameObject.Find("Event").GetComponent<Event>().killcnt += 1;
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            //delay
            yield return new WaitForSeconds(0.7f + Random.Range(0, 0.3f));
            Shoot();
            yield return new WaitForSeconds(0.7f);
            Shoot();
            yield return new WaitForSeconds(0.7f);
            cool = false;
            if (attack == 0)
            {
                transform.parent.gameObject.GetComponent<EnemyMove>().attackcool = true;
            }
            yield break;
        }
    }

    private void Summon()
    {
        Vector3 pos = transform.position + Vector3.right;
        pos.z = 5;
        GameObject i = Instantiate(Fre, pos, Quaternion.Euler(0, 0, 0));
        i.GetComponent<EnemyMove>().move = -1;

        pos = transform.position + Vector3.left;
        pos.z = 5;
        i = Instantiate(Fre, pos, Quaternion.Euler(0, 0, 0));
        i.GetComponent<EnemyMove>().move = -1;
    }
}