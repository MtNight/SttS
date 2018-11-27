using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPro : MonoBehaviour {

    public int atk;
    public int attack;
    public bool attackcool;
    private int hp;
    private float posy;
    
    private Animator Ranim;
    private SpriteRenderer RSR;
    private AudioSource audioSource;
    public AudioClip ShootSound;
    public AudioClip HitSound;
    public AudioClip DownSound;

    void Start () {
        atk = 1;
        attack = 0;
        attackcool = false;
        hp = 100;
        posy = Random.Range(0.0f, 1.0f) - 74.5f;

        Ranim = transform.GetChild(0).GetComponent<Animator>();
        RSR = transform.GetChild(0).GetComponent<SpriteRenderer>();
        RSR.enabled = false;

        if (transform.position.x > 90)
        {
            Vector3 tmp = transform.localScale;
            tmp.x *= -1;
            transform.localScale = tmp;
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(DownSound);
    }
	
	void Update () {
        if (transform.position.y > posy)
        {
            transform.position += new Vector3(0, -5, 0) * Time.deltaTime;
        }
        else
        {
            if (attack == 0)
            {
                StartCoroutine(DownAttack());
            }
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

        if (hp <= 0)
        {
            GameObject.Find("Event").GetComponent<Event>().killcnt += 1;
            Destroy(this.gameObject);
        }
    }

    IEnumerator DownAttack()
    {
        while (true)
        {
            attack = 1;
            RSR.enabled = true;
            Ranim.SetBool("attack", false);
            yield return new WaitForSeconds(3.0f);
            audioSource.PlayOneShot(ShootSound);
            attack = 2;
            Ranim.SetBool("attack", true);
            yield return new WaitForSeconds(4.0f);
            attack = 1;
            Ranim.SetBool("attack", false);
            RSR.enabled = false;
            yield return new WaitForSeconds(5.0f);
            attack = 0;
            yield break;
        }
    }
    public IEnumerator DemegeCool()
    {
        while (true)
        {
            attackcool = true;
            yield return new WaitForSeconds(0.05f);
            attackcool = false;
            yield break;
        }
    }
}
