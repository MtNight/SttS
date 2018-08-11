using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {   //Player's overall moving

    public bool l;
    public bool r;
    public bool jumping;
    public int land;
    private float Speed;
    private Vector3 moveArrow;
    public Vector3 dir;
    private Rigidbody2D rigid;
    private GameObject player;

	void Start () {
        l = true;   //왼쪽 이동 가능
        r = true;   //오른쪽 이동 가능
        jumping = true;   //점프 가능
        land = 0;   //밟고 있는 땅 수
        Speed = 5.0f;   //속도
        moveArrow = Vector3.zero;   //이동 방향
        dir = Vector3.right;   //보고 있는 방향
        rigid = this.GetComponent<Rigidbody2D>();   //Rigidbody컴포넌트
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
            land += 1;
            rigid.velocity = Vector3.zero;
            rigid.gravityScale = 0;
            Vector3 i = transform.position;
            i.y = other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f + 0.86f;
            transform.position = i;
        }
        else if (other.tag == "Platform")
        {
            land += 1;
            if (rigid.velocity.y <= 0 && transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y)
            {
                jumping = false;
                rigid.velocity = Vector3.zero;
                rigid.gravityScale = 0;
                Vector3 i = transform.position;
                i.y = other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f + 0.86f;
                transform.position = i;
            }
        }
        else if (other.tag == "Block")
        {
            land += 1;
            if (rigid.velocity.y <= 0 && transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
            {
                jumping = false;
                rigid.velocity = Vector3.zero;
                rigid.gravityScale = 0;
                Vector3 i = transform.position;
                i.y = other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f + 0.86f;
                transform.position = i;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Land" || other.tag == "Platform" || other.tag == "Block")
        {
            if (jumping == true)
            {
                if (rigid.velocity.y >= 0 || transform.position.y - 0.6f < other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
                {
                    rigid.gravityScale = 2;
                    if (rigid.velocity.y == 0)
                    {
                        jumping = false;
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Land" || other.tag == "Platform" || other.tag == "Block")
        {
            land -= 1;
            if (rigid.velocity.y >= 0)
            {
                if (land == 0)
                {
                    rigid.gravityScale = 2;
                }
            }
        }
    }
}
