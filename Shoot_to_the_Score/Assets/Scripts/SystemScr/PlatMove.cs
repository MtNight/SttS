using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMove : MonoBehaviour {

    public bool act;
    private float speed;
    public Vector3 dir;
    public Vector3 move;

	void Start () {
        act = false;
        speed = 3f;
        dir = Vector3.down;
	}
	
	void Update () {
        if (act == true)
        {
            move = speed * dir * Time.deltaTime;
            transform.position += move;
        }
        else
        {
            move = new Vector3(0, 0, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform" || other.tag == "Land")
        {
            if (act == true)
            {
                act = false;
                if (dir.y > 0)
                {
                    move = new Vector3(0, 0, 0);
                    dir = Vector3.down;
                    StartCoroutine("cool");

                }
                else
                {
                    move = new Vector3(0, 0, 0);
                    dir = Vector3.up;
                    StartCoroutine("cool");
                }
            }
        }
    }

    IEnumerator cool()
    {
        while (true)
        {
            act = false;
            yield return new WaitForSeconds(3.0f);
            act = true;
            yield break;
        }
    }
}
