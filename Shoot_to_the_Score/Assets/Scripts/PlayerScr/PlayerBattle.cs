using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour {   //Shoot and BeAttack code

    private bool cool;
    public int maxMagazine;
    private int mag;
    private int bulletKind;
    private Vector3 dir;
    private GameObject bullet;

	void Start () {
        cool = false;
        maxMagazine = 30;
        mag = 30;
        bulletKind = 0;
        dir = transform.parent.gameObject.GetComponent<PlayerMove>().dir;
        bullet = Resources.Load("NormalpBullet") as GameObject;
    }
	
	void Update () {
        if (bulletKind == 0)
        {
            bullet = Resources.Load("NormalpBullet") as GameObject;   //in Resources folder
        }
        else if (bulletKind == 1)
        {
            bullet = Resources.Load("NormalpBullet") as GameObject;
        }
        else if (bulletKind == 2)
        {
            bullet = Resources.Load("NormalpBullet") as GameObject;
        }
        else if (bulletKind == 3)
        {
            bullet = Resources.Load("NormalpBullet") as GameObject;
        }

        if (Input.GetKeyDown(KeyCode.X) && cool == false)
        {
            if (mag == 0)
            {
                //Find Magazine
            }
            else
            {
                mag -= 1;
                dir = transform.parent.gameObject.GetComponent<PlayerMove>().dir / 5;
                dir += transform.position;
                dir.z = 6;
                Instantiate(bullet, dir, Quaternion.Euler(0, 0, 0));
                StartCoroutine(ShootCool(1.0f));
            }
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
}
