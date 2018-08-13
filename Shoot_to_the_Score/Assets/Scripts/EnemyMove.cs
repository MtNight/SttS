using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public bool l;
    public bool r;
    public bool jumping;
    public bool jumpable;
    public bool attackcool;
    public int land;
    public int move;
    public float x1;
    public float x2;
    private float Speed;
    private Vector3 moveArrow;
    public Vector3 dir;
    private Rigidbody2D rigid;
    public GameObject player;
    private GameObject cam;

    void Start()
    {
        l = true;   //왼쪽 이동 가능
        r = true;   //오른쪽 이동 가능
        jumping = true;   //점프 중임
        jumpable = false;
        attackcool = false;
        land = 0;   //밟고 있는 땅 수
        move = -2;
        Speed = 2.5f;   //속도
        moveArrow = Vector3.zero;   //이동 방향
        dir = Vector3.left;   //보고 있는 방향
        player = GameObject.Find("Player");
        rigid = this.GetComponent<Rigidbody2D>();   //Rigidbody컴포넌트
        cam = GameObject.Find("Game Camera");

    }

    void Update()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("Game Camera");
        x1 = player.transform.position.x;
        x2 = cam.transform.position.x;

        moveArrow = Vector3.zero;
        Vector3 i = transform.localScale;
        if (move == -2)
        {
            jumpable = false;
            if (Mathf.Abs(cam.transform.position.x - player.transform.position.x) < 10)
            {
                StartCoroutine("Attack");
                move = 0;
            }
        }
        else if (move == -1)
        {
            jumpable = false;
            if (player.transform.position.x >= transform.position.x && r == true)
            {
                moveArrow = Vector3.right;
                dir = Vector3.right;
                if (i.x != Mathf.Abs(i.x))
                {
                    i.x = Mathf.Abs(i.x);
                    transform.localScale = i;
                }
            }
            else if (player.transform.position.x < transform.position.x && l == true)
            {
                moveArrow = Vector3.left;
                dir = Vector3.left;
                if (i.x != -Mathf.Abs(i.x))
                {
                    i.x = -Mathf.Abs(i.x);
                    transform.localScale = i;
                }
            }
            transform.position += Speed * moveArrow * Time.deltaTime;
            if (cam.transform.position.x - transform.position.x < 1 && cam.transform.position.x - transform.position.x > -19)
            {
                StartCoroutine("Attack");
                move = 0;
            }
        }
        else if (move == 0)
        {
            jumpable = false;
            if (attackcool == true)
            {
                if (Mathf.Abs(player.transform.position.x - transform.position.x) < 8)
                {
                    StartCoroutine("Back");
                    move = 2;
                }
                else
                {
                    StartCoroutine("Close");
                    move = 1;
                }
            }
        }
        else if (move == 1)
        {
            jumpable = true;
            if (player.transform.position.x > transform.position.x && r == true)
            {
                moveArrow = Vector3.right;
                dir = Vector3.right;
                if (i.x != Mathf.Abs(i.x))
                {
                    i.x = Mathf.Abs(i.x);
                    transform.localScale = i;
                }
            }
            else if (player.transform.position.x < transform.position.x && l == true)
            {
                moveArrow = Vector3.left;
                dir = Vector3.left;
                if (i.x != -Mathf.Abs(i.x))
                {
                    i.x = -Mathf.Abs(i.x);
                    transform.localScale = i;
                }
            }
            transform.position += Speed * moveArrow * Time.deltaTime;
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 8)
            {
                if (attackcool == false)
                {
                    StartCoroutine("Attack");
                    move = 0;
                }
            }
        }
        else if (move == 2)
        {
            jumpable = true;
            if (Mathf.Abs(cam.transform.position.x - transform.position.x) <= 9)
            {
                if (player.transform.position.x > transform.position.x && l == true)
                {
                    moveArrow = Vector3.left;
                    dir = Vector3.left;
                    if (i.x != -Mathf.Abs(i.x))
                    {
                        i.x = -Mathf.Abs(i.x);
                        transform.localScale = i;
                    }
                }
                else if (player.transform.position.x < transform.position.x && r == true)
                {
                    moveArrow = Vector3.right;
                    dir = Vector3.right;
                    if (i.x != Mathf.Abs(i.x))
                    {
                        i.x = Mathf.Abs(i.x);
                        transform.localScale = i;
                    }
                }
                if (Mathf.Abs(player.transform.position.x - transform.position.x) < 8)
                {
                    transform.position += Speed * moveArrow * Time.deltaTime;
                }
                else
                {
                    transform.position += Speed * moveArrow * Time.deltaTime * 0.75f;
                }
                if (attackcool == false)
                {
                    StartCoroutine("Attack");
                    move = 0;
                }
            }
            else
            {
                if (cam.transform.position.x < transform.position.x && l == true)
                {
                    moveArrow = Vector3.left;
                    dir = Vector3.left;
                    if (i.x != -Mathf.Abs(i.x))
                    {
                        i.x = -Mathf.Abs(i.x);
                        transform.localScale = i;
                    }
                }
                else if (cam.transform.position.x > transform.position.x && r == true)
                {
                    moveArrow = Vector3.right;
                    dir = Vector3.right;
                    if (i.x != Mathf.Abs(i.x))
                    {
                        i.x = Mathf.Abs(i.x);
                        transform.localScale = i;
                    }
                }
                transform.position += Speed * moveArrow * Time.deltaTime * 1.25f;
                move = 3;
            }

            
        }
        else if (move == 3)
        {
            jumpable = true;
            if (attackcool == false)
            {
                StartCoroutine("Attack");
                move = 0;
            }
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

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            attackcool = true;
            yield break;
        }
    }
    IEnumerator Close()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            attackcool = false;
            yield break;
        }
    }
    IEnumerator Back()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            attackcool = false;
            yield break;
        }
    }
}
