using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle1 : MonoBehaviour {

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

    void Start()
    {
        fire = false;
        cool = false;
        dead = false;
        hp = 100;
        dir = transform.parent.gameObject.GetComponent<EnemyMove>().dir;
        bullet = Resources.Load("TalenteBullet") as GameObject;
        cam = GameObject.Find("Game Camera");
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update ()
    {
        cam = GameObject.Find("Game Camera");
        if (Mathf.Abs(cam.transform.position.x - transform.position.x) < 10 && Mathf.Abs(cam.transform.position.y - transform.position.y) < 5.625f)
        {
            attack = transform.parent.gameObject.GetComponent<EnemyMove>().move;
            if (attack == 0 && cool == false)
            {
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
            pos.z = 6;
            GameObject i = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));
            i.GetComponent<eBullet>().dir = dir;
            i.GetComponent<eBullet>().atk = 10;
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
            yield return new WaitForSeconds(0.1f);
            Shoot();
            yield return new WaitForSeconds(0.1f);
            Shoot();
            //del
            yield return new WaitForSeconds(0.5f);
            Shoot();
            yield return new WaitForSeconds(0.1f);
            Shoot();
            yield return new WaitForSeconds(0.1f);
            Shoot();
            //dle
            yield return new WaitForSeconds(0.5f);
            cool = false;
            if (attack == 0)
            {
                transform.parent.gameObject.GetComponent<EnemyMove>().attackcool = true;
            }
            yield break;
        }
    }
}
