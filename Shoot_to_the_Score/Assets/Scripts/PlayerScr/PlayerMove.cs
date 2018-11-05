using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {   //Player's overall moving

    public bool l;
    public bool r;
    public bool jumping;
    public bool mp;
    public int land;
    private float Speed;
    public float multi;
    private Vector3 moveArrow;
    public Vector3 dir;
    private Rigidbody2D rigid;
    private AudioSource audioSource;
    public AudioClip JumpSound;
    private Animator anim;

    void Start () {
        l = true;   //왼쪽 이동 가능
        r = true;   //오른쪽 이동 가능
        jumping = true;   //점프 가능
        mp = false;   //움직이는 발판
        land = 0;   //밟고 있는 땅 수
        Speed = 5.0f;   //속도
        multi = 1.0f;
        moveArrow = Vector3.zero;   //이동 방향
        dir = Vector3.right;   //보고 있는 방향
        rigid = this.GetComponent<Rigidbody2D>();   //Rigidbody컴포넌트
        audioSource = GetComponent<AudioSource>();
        anim = this.GetComponent<Animator>();
    }
	
	void Update () {
        if (land == 0)
        {
            rigid.gravityScale = 2;
        }
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
        transform.position += moveArrow * Speed * Time.deltaTime * multi;

        //jump
        if (jumping == true)
        {
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up * 510.0f);
            audioSource.PlayOneShot(JumpSound);
        }

        if (moveArrow.x == 0)
        {
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("run", true);
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
        else if (other.tag == "Platform" || other.tag == "MPlatform")
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
                if (other.tag == "MPlatform")
                {
                    transform.position += other.GetComponent<PlatMove>().move;
                    mp = true;
                }
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
        if (other.tag == "MPlatform")
        {
            mp = true;
            transform.position += other.GetComponent<PlatMove>().move;
            if (jumping == true && transform.position.y >= other.transform.position.y)
            {
                rigid.gravityScale = 0;
                rigid.velocity = Vector3.zero;
                jumping = false;
            }
            if (transform.position.y - 1.2f <= other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
            {
                Vector3 tmp = transform.position;
                tmp.y = other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f + 0.9f;
                transform.position = tmp;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Land" || other.tag == "Platform" || other.tag == "Block" || other.tag == "MPlatform")
        {
            land -= 1;
            if (other.tag == "MPlatform")
            {
                transform.position += other.GetComponent<PlatMove>().move;
                mp = false;
                StartCoroutine("Check_Position");
            }
            else
            {
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

    public IEnumerator ED()
    {
        while (true)
        {
            multi = 1.5f;
            yield return new WaitForSeconds(10.0f);
            multi = 1.0f;
            yield break;
        }
    }

    public IEnumerator Check_Position()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (mp == false)
            {
                if (rigid.velocity.y >= 0)
                {
                    if (land == 0)
                    {
                        rigid.gravityScale = 2;
                        yield break;
                    }
                }
            }
        }
    }
}
