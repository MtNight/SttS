using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour {   //Shoot and BeAttack code

    private bool load;
    private bool cool;
    public int hp;
    public int atk;
    public int maxMagazine;
    public int mag;
    public int bulletKind;
    public float multi;
    private Vector3 dir;
    private GameObject bullet;
    private AudioSource audioSource;
    public AudioClip ShootSound;
    public AudioClip LoadSound;
    public AudioClip HitSound;

    void Start () {
        load = false;
        cool = false;
        hp = 500;
        maxMagazine = 30;
        mag = 30;
        bulletKind = 0;
        multi = 1.0f;
        dir = transform.parent.gameObject.GetComponent<PlayerMove>().dir;
        bullet = Resources.Load("NormalpBullet") as GameObject;
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update () {
        if (hp > 500) { hp = 500; }
        multi = transform.parent.gameObject.GetComponent<PlayerMove>().multi;
        if (bulletKind == 0)
        {
            bullet = Resources.Load("NormalpBullet") as GameObject;   //in Resources folder
            atk = 30;
        }
        else if (bulletKind == 1)
        {
            bullet = Resources.Load("EffortpBullet") as GameObject;
            atk = 40;
        }
        else if (bulletKind == 2)
        {
            bullet = Resources.Load("TalentpBullet") as GameObject;
            atk = 50;
        }
        else if (bulletKind == 3)
        {
            bullet = Resources.Load("PlaypBullet") as GameObject;
            atk = 100;
        }

        if (Input.GetKeyDown(KeyCode.X) && cool == false && load == false)
        {
            if (mag == 0)
            {
                StartCoroutine(Reload(1.0f / multi));
            }
            else
            {
                mag -= 1;
                dir = transform.parent.gameObject.GetComponent<PlayerMove>().dir / 5;
                dir += transform.position;
                dir.y -= 0.2f;
                dir.z = 6;
                GameObject i = Instantiate(bullet, dir, Quaternion.Euler(0, 0, 0));
                i.GetComponent<pBullet>().atk = atk;
                i.GetComponent<pBullet>().speed = 10.0f * multi;
                StartCoroutine(ShootCool(1.0f / multi));
                audioSource.PlayOneShot(ShootSound);
            }
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.R)) && load == false)
        {
            StartCoroutine(Reload(1.0f / multi));
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "eBullet")
        {
            hp -= other.gameObject.GetComponent<eBullet>().atk;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(HitSound);
        }
        if (hp <= 0)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    IEnumerator ShootCool(float t)
    {
        while (true)
        {
            cool = true;
            yield return new WaitForSeconds(0.1f * t);
            cool = false;
            yield break;
        }
    }

    IEnumerator Reload(float t)
    {
        while (true)
        {

            audioSource.PlayOneShot(LoadSound);
            load = true;
            yield return new WaitForSeconds(1.0f * t);
            load = false;
            mag = 30;
            yield break;
        }
    }
}
