﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eBullet : MonoBehaviour {

    public int atk;
    protected int demage;
    public float speed;
    public Vector3 dir;

    void Start()
    {
        speed = 10.0f;
    }

    void Update()
    {
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
