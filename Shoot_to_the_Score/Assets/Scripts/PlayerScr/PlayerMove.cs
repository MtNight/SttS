using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public bool l;
    public bool r;
    public bool jumping;
    private float Speed;
    private Vector3 moveArrow;
    private Vector3 dir;
    private Rigidbody2D rigid;
    private GameObject player;

	void Start () {
        l = true;
        r = true;
        jumping = true;
        Speed = 5.0f;
        moveArrow = Vector3.zero;
        dir = Vector3.right;
        rigid = this.GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        //move
        moveArrow = Vector3.zero;
        Vector3 i = transform.localScale;
        if (Input.GetKey(KeyCode.LeftArrow) && l == true)
        {
            moveArrow = Vector3.left;
            dir = Vector3.left;
            if (i.x != -Mathf.Abs(i.x))
            {
                i.x = -Mathf.Abs(i.x);
                transform.localScale = i;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && r == true)
        {
            moveArrow = Vector3.right;
            dir = Vector3.right;
            if (i.x != Mathf.Abs(i.x))
            {
                i.x = Mathf.Abs(i.x);
                transform.localScale = i;
            }
        }
        transform.position += moveArrow * Speed * Time.deltaTime;

        //jump
        if (jumping == true)
        {
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up * 500.0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Land")
        {
            jumping = false;
            rigid.velocity = Vector3.zero;
            rigid.gravityScale = 0;
        }
        else if (other.tag == "Platform")
        {
            if (rigid.velocity.y <= 0 && transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y)
            {
                jumping = false;
                rigid.velocity = Vector3.zero;
                rigid.gravityScale = 0;
                Vector3 i = transform.position;
                i.y = other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y + 0.725f;
                transform.position = i;
            }
        }
        else if (other.tag == "Block")
        {
            if (rigid.velocity.y <= 0 && transform.position.y - 0.85f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y)
            {
                jumping = false;
                rigid.velocity = Vector3.zero;
                rigid.gravityScale = 0;
                Vector3 i = transform.position;
                i.y = other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * 3 + 0.725f;
                transform.position = i;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (jumping == true)
        {
            if (rigid.velocity.y == 0)
            {
                jumping = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Land")
        {
            rigid.gravityScale = 2;
        }
        else if (other.tag == "Platform" || other.tag == "Block")
        {
            if (rigid.velocity.y >= 0)
            {
                rigid.gravityScale = 2;
            }
        }
    }
}
