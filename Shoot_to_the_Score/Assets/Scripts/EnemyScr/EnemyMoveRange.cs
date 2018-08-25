using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRange : MonoBehaviour {

    private int range;
    private int block;
    private GameObject enemy;
    private Rigidbody2D erigid;

    void Start()
    {
        range = 0;
        block = 0;
        enemy = transform.parent.gameObject;
        erigid = enemy.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform" || other.tag == "Block")
        {
            range += 1;
            if (other.tag == "Block")
            {
                block += 1;
                if (erigid.velocity.y <= 0 && transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
                {
                    if (block == 1)
                    {
                        enemy.GetComponent<EnemyMove>().r = true;
                        enemy.GetComponent<EnemyMove>().l = true;
                    }
                }
                else {
                    if (erigid.velocity.y > 0 && transform.position.y + 0.6f < other.transform.position.y - other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
                    {
                        erigid.velocity = Vector3.zero;
                    }
                    else
                    {
                        if (transform.position.x >= other.transform.position.x && enemy.GetComponent<EnemyMove>().r != false)
                        {
                            enemy.GetComponent<EnemyMove>().l = false;
                        }
                        else if (transform.position.x <= other.transform.position.x && enemy.GetComponent<EnemyMove>().l != false)
                        {
                            enemy.GetComponent<EnemyMove>().r = false;
                        }

                        //if (enemy.GetComponent<EnemyMove>().jumping == true)
                        //{
                        //}
                        //else if (enemy.GetComponent<EnemyMove>().jumpable == true && enemy.GetComponent<EnemyMove>().player.transform.position.y >= enemy.transform.position.y)
                        //{
                        //    enemy.GetComponent<EnemyMove>().jumping = true;
                        //    erigid.velocity = Vector3.zero;
                        //    erigid.AddForce(Vector3.up * 500.0f);
                        //}
                    }
                }
                if (enemy.GetComponent<EnemyMove>().land - range <= 1)
                {
                    if (enemy.GetComponent<EnemyMove>().jumping == true)
                    {
                    }
                    else if (enemy.GetComponent<EnemyMove>().jumpable == true)
                    {
                        if ((enemy.GetComponent<EnemyMove>().move == 1 && enemy.GetComponent<EnemyMove>().player.transform.position.y > enemy.transform.position.y) || (enemy.GetComponent<EnemyMove>().move == 2 && Mathf.Abs(enemy.GetComponent<EnemyMove>().player.transform.position.y - enemy.transform.position.y) < 2))
                        {
                            enemy.GetComponent<EnemyMove>().jumping = true;
                            erigid.velocity = Vector3.zero;
                            erigid.AddForce(Vector3.up * 510.0f);
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Block" || other.tag == "Platform")
        {
            range -= 1;
            if (enemy.GetComponent<EnemyMove>().land - range <= 2)
            {
                if (enemy.GetComponent<EnemyMove>().jumping == true)
                {
                }
                else if (enemy.GetComponent<EnemyMove>().jumpable == true)
                {
                    if ((enemy.GetComponent<EnemyMove>().move == 1 && enemy.GetComponent<EnemyMove>().player.transform.position.y > enemy.transform.position.y) || (enemy.GetComponent<EnemyMove>().move == 2 && enemy.GetComponent<EnemyMove>().player.transform.position.y < enemy.transform.position.y))
                    {
                        enemy.GetComponent<EnemyMove>().jumping = true;
                        erigid.velocity = Vector3.zero;
                        erigid.AddForce(Vector3.up * 510.0f);
                    }
                }
            }
            if (other.tag == "Block")
            {
                block -= 1;
                if (block == 0)
                {
                    if (enemy.GetComponent<EnemyMove>().r == false)
                    {
                        enemy.GetComponent<EnemyMove>().r = true;
                    }
                    else if (enemy.GetComponent<EnemyMove>().l == false)
                    {
                        enemy.GetComponent<EnemyMove>().l = true;
                    }
                }
            }
        }
    }
}
