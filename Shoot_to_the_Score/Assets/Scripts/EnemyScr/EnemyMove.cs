using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public bool el;
    public bool er;
    public bool jumping;
    public bool jumpable;
    public bool attackcool;
    public int land;
    public int move;
    public float x1;
    public float x2;
    private int random;
    private int rand;
    private float Speed;
    public Vector3 moveArrow;
    public Vector3 dir;
    private Rigidbody2D rigid;
    public GameObject player;
    private GameObject cam;
    private Animator anim;

    void Start()
    {
        el = true;   //왼쪽 이동 가능
        er = true;   //오른쪽 이동 가능
        jumping = true;   //점프 중임
        jumpable = false;
        attackcool = true;
        land = 0;   //밟고 있는 땅 수
        if (move != -1)
        {
            move = -2;
        }
        random = Random.Range(-1, 1);
        Speed = 3.0f - random;   //속도
        moveArrow = Vector3.zero;   //이동 방향
        dir = Vector3.left;   //보고 있는 방향
        player = GameObject.Find("Player");
        rigid = this.GetComponent<Rigidbody2D>();   //Rigidbody컴포넌트
        cam = GameObject.Find("Game Camera");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            cam = GameObject.Find("Game Camera");
            x1 = player.transform.position.x;
            x2 = cam.transform.position.x;
        }
        if (move == -2)
        {
            anim.SetBool("run", false);
            jumpable = false;
            if (Mathf.Abs(cam.transform.position.x - transform.position.x) < 10 && Mathf.Abs(cam.transform.position.y - transform.position.y) < 5.625f)
            {
                attackcool = false;
                StartCoroutine("Attack");
            }
        }
        else if (move == -1)
        {
            anim.SetBool("run", true);
            jumpable = false;
            moveArrow = Vector3.zero;
            Vector3 i = transform.localScale;
            if (x1 >= transform.position.x && er == true)
            {
                moveArrow = Vector3.right;
                dir = Vector3.right;
                if (i.x != -Mathf.Abs(i.x))
                {
                    i.x = -Mathf.Abs(i.x);
                    transform.localScale = i;
                }
            }
            else if (x1 < transform.position.x && el == true)
            {
                moveArrow = Vector3.left;
                dir = Vector3.left;
                if (i.x != Mathf.Abs(i.x))
                {
                    i.x = Mathf.Abs(i.x);
                    transform.localScale = i;
                }
            }
            transform.position += Speed * moveArrow * Time.deltaTime;
            if (cam.transform.position.x - transform.position.x > -9 && cam.transform.position.x - transform.position.x < 9)
            {
                attackcool = false;
                StartCoroutine("Attack");
            }
        }
        else if (move == 0)
        {
            anim.SetBool("run", false);
            random = Random.Range(0, 10);
            jumpable = false;
            moveArrow = Vector3.zero;
            Vector3 i = transform.localScale;

        if (attackcool == true)
            {
                if (Mathf.Abs(cam.transform.position.x - transform.position.x) < 10 && Mathf.Abs(cam.transform.position.y - transform.position.y) < 5.625f)
                {
                    if (Mathf.Abs(x1 - transform.position.x) < 8)
                    {
                        rand = 7;
                    }
                    else
                    {
                        rand = 3;
                    }
                    if (rand > random)
                    {
                        StartCoroutine("Back");
                        move = 2;
                        if (x1 > transform.position.x && el == true)
                        {
                            moveArrow = Vector3.left;
                            dir = Vector3.left;
                            if (i.x != Mathf.Abs(i.x))
                            {
                                i.x = Mathf.Abs(i.x);
                                transform.localScale = i;
                            }
                        }
                        else if (x1 < transform.position.x && er == true)
                        {
                            moveArrow = Vector3.right;
                            dir = Vector3.right;
                            if (i.x != -Mathf.Abs(i.x))
                            {
                                i.x = -Mathf.Abs(i.x);
                                transform.localScale = i;
                            }
                        }
                    }
                    else
                    {
                        StartCoroutine("Close");
                        move = 1;
                        if (x1 > transform.position.x && er == true)
                        {
                            moveArrow = Vector3.right;
                            dir = Vector3.right;
                            if (i.x != -Mathf.Abs(i.x))
                            {
                                i.x = -Mathf.Abs(i.x);
                                transform.localScale = i;
                            }
                        }
                        else if (x1 < transform.position.x && el == true)
                        {
                            moveArrow = Vector3.left;
                            dir = Vector3.left;
                            if (i.x != Mathf.Abs(i.x))
                            {
                                i.x = Mathf.Abs(i.x);
                                transform.localScale = i;
                            }
                        }
                    }
                }
            }
        }
        else if (move == 1)
        {
            anim.SetBool("run", true);
            jumpable = true;
            if ((er == true && moveArrow.x == 1) || (el == true && moveArrow.x == -1))
            {
                if (Mathf.Abs(cam.transform.position.x - transform.position.x) < 10 && Mathf.Abs(cam.transform.position.y - transform.position.y) < 5.625f)
                {
                    transform.position += Speed * moveArrow * Time.deltaTime;
                }
            }
            if (Mathf.Abs(x1 - transform.position.x) < 8)
            {
                if (attackcool == false)
                {
                    StartCoroutine("Attack");
                }
            }
        }
        else if (move == 2)
        {
            anim.SetBool("run", true);
            jumpable = true;
            if (Mathf.Abs(cam.transform.position.x - transform.position.x) <= 9)
            {
                if (Mathf.Abs(cam.transform.position.x - transform.position.x) < 10 && Mathf.Abs(cam.transform.position.y - transform.position.y) < 5.625f)
                {
                    if (Mathf.Abs(x1 - transform.position.x) < 8)
                    {
                        if ((er == true && moveArrow.x == 1) || (el == true && moveArrow.x == -1))
                        {
                            transform.position += Speed * moveArrow * Time.deltaTime;
                        }
                    }
                    else
                    {
                        if ((er == true && moveArrow.x == 1) || (el == true && moveArrow.x == -1))
                        {
                            transform.position += Speed * moveArrow * Time.deltaTime * 0.75f;
                        }
                    }
                }
                if (attackcool == false)
                {
                    StartCoroutine("Attack");
                }
            }
            else
            {
                if (cam.transform.position.x < transform.position.x && el == true)
                {
                    moveArrow = Vector3.left;
                    dir = Vector3.left;
                    Vector3 i = transform.localScale;
                    if (i.x != Mathf.Abs(i.x))
                    {
                        i.x = Mathf.Abs(i.x);
                        transform.localScale = i;
                    }
                }
                else if (cam.transform.position.x > transform.position.x && er == true)
                {
                    moveArrow = Vector3.right;
                    dir = Vector3.right;
                    Vector3 i = transform.localScale;
                    if (i.x != -Mathf.Abs(i.x))
                    {
                        i.x = -Mathf.Abs(i.x);
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
            Vector3 i = transform.localScale;
            if (x1 > transform.position.x)
            {
                dir = Vector3.right;
                if (i.x != -Mathf.Abs(i.x))
                {
                    i.x = -Mathf.Abs(i.x);
                    transform.localScale = i;
                }
            }
            else
            {
                dir = Vector3.left;
                if (i.x != Mathf.Abs(i.x))
                {
                    i.x = Mathf.Abs(i.x);
                    transform.localScale = i;
                }
            }

            move = 0;
            yield return new WaitForSeconds(1.9f);
            if (move == 0)
            {
                attackcool = true;
            }
            yield break;
        }
    }
    IEnumerator Close()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.6f + Random.Range(0, 0.4f));
            attackcool = false;
            yield break;
        }
    }
    IEnumerator Back()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f + Random.Range(0, 0.6f));
            attackcool = false;
            yield break;
        }
    }
}
