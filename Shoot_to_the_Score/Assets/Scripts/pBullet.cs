using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pBullet : MonoBehaviour {   //Bullet flying code

    protected int demage;
    private float speed;
    private Vector3 dir;

	void Start () {
        speed = 10.0f;
        if (GameObject.Find("Player").transform.position.x > transform.position.x)
        {
            dir = Vector3.left;
        }
        else
        {
            dir = Vector3.right;
        }
	}
	
	void Update () {
        transform.position += speed * dir * Time.deltaTime;
	}

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            Destroy(this.gameObject);
        }
    }
}
