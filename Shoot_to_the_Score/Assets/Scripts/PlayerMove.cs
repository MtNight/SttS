using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public bool jumping;
    private float Speed;
    private Vector3 moveArrow;
    private Vector3 dir;
    private Rigidbody2D rigid;
    private GameObject player;

	void Start () {
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveArrow = Vector3.left;
            if (i.x != -Mathf.Abs(i.x))
            {
                i.x = -Mathf.Abs(i.x);
                transform.localScale = i;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveArrow = Vector3.right;
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
            if (rigid.velocity.y == 0)
            {
                jumping = false;
            }
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
            if (rigid.velocity.y <= 0 && transform.position.y - 0.6 > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y)
            {
                jumping = false;
                rigid.velocity = Vector3.zero;
                rigid.gravityScale = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Land")
        {
            rigid.gravityScale = 2;
        }
        else if (other.tag == "Platform")
        {
            if (rigid.velocity.y >= 0)
            {
                rigid.gravityScale = 2;
            }
        }
    }
}
