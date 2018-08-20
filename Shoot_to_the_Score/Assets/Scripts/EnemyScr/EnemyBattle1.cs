using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle1 : MonoBehaviour {

    public bool fire;
    public bool cool;
    public int hp;
    public int attack;
    public Vector3 dir;
    public Vector3 pos;
    public GameObject bullet;

    void Start()
    {
        fire = false;
        cool = false;
        hp = 100;
        dir = transform.parent.gameObject.GetComponent<EnemyMove>().dir;
        bullet = Resources.Load("EfforteBullet") as GameObject;
    }
    
    void Update ()
    {
        attack = transform.parent.gameObject.GetComponent<EnemyMove>().move;
        if (attack == 0 && cool == false)
        {
            cool = true;
            StartCoroutine("Attack");
        }
    }
    private void Shoot()
    {
        dir = transform.parent.gameObject.GetComponent<EnemyMove>().dir;
        pos = transform.parent.gameObject.GetComponent<EnemyMove>().dir / 5.0f;
        pos += transform.position;
        pos.x += 0.1f;
        pos.y -= 0.1f;
        pos.z = 6;
        GameObject i = Instantiate(bullet, pos, Quaternion.Euler(0, 0, 0));
        i.GetComponent<eBullet>().dir = dir;
        i.GetComponent<eBullet>().atk = 30;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pBullet")
        {
            hp -= other.gameObject.GetComponent<pBullet>().atk;
            Destroy(other.gameObject);
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            //delay
            yield return new WaitForSeconds(0.7f);
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
