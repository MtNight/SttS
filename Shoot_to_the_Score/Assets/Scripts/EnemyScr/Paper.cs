using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{

    public int atk;
    protected int demage;
    public float speed;
    public Vector3 dir;

    void Start()
    {
        dir = new Vector3(0, -0.005f, 0);
        speed = 3.0f;
    }

    void Update()
    {
        dir.x += Random.Range(-0.1f, 0.1f);
        if (dir.x > 1)
        {
            dir.x = 0.5f;
        }
        if (dir.x < -1)
        {
            dir.x = -0.5f;
        }
        dir.y += Random.Range(-0.001f, -0.01f);
        if (dir.y > -0.1f)
        {
            dir.x = -0.05f;
        }
        transform.position += speed * dir * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, dir.x));
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
