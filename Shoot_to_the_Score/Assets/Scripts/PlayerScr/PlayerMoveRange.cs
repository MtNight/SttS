using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRange : MonoBehaviour {   //Player's moving under block and both side of block

    public int block;
    private GameObject player;
    private Rigidbody2D prigid;

	void Start () {
        block = 0;
        player = GameObject.Find("Player");
        prigid = player.GetComponent<Rigidbody2D>();
	}

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = GameObject.Find("Player");
        if (other.tag == "Block" && player != null)
        {
            block += 1;
            if (prigid.velocity.y <= 0 && transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
            {
                if (block == 1)
                {
                    if (player.GetComponent<PlayerMove>().pr == false)
                    {
                        player.GetComponent<PlayerMove>().pr = true;
                    }
                    if (player.GetComponent<PlayerMove>().pl == false)
                    {
                        player.GetComponent<PlayerMove>().pl = true;
                    }
                }
            }
            if (!(prigid.velocity.y <= 0 && transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f))
            {

                if (prigid.velocity.y > 0 && transform.position.y + 0.6f < other.transform.position.y - other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
                {
                    prigid.velocity = Vector3.zero;
                }
                else
                {
                    if (transform.position.x < other.transform.position.x && player.GetComponent<PlayerMove>().pl != false)
                    {
                        player.GetComponent<PlayerMove>().pr = false;
                    }
                    if (transform.position.x > other.transform.position.x && player.GetComponent<PlayerMove>().pr != false)
                    {
                        player.GetComponent<PlayerMove>().pl = false;
                    }
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Land")
        {
            if (block == 0)
            {
                player.GetComponent<PlayerMove>().pr = true;
                player.GetComponent<PlayerMove>().pl = true;
            }
            else if (block == 1)
            {
                player.GetComponent<PlayerMove>().pr = true;
                player.GetComponent<PlayerMove>().pl = true;
            }
        }
        if (other.tag == "Block")
        {
            if (prigid.velocity.y == 0)
            {   //서있음
                if (transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
                {   //위에 서있다.
                    if (block == 1)
                    {
                        if (player.GetComponent<PlayerMove>().pr == false)
                        {
                            player.GetComponent<PlayerMove>().pr = true;
                        }
                        if (player.GetComponent<PlayerMove>().pl == false)
                        {
                            player.GetComponent<PlayerMove>().pl = true;
                        }
                    }
                }
                if (!(transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f))
                {   //옆에 서있다.
                    if (block != 0)
                    {
                        if (transform.position.x < other.transform.position.x && player.GetComponent<PlayerMove>().pl != false)
                        {
                            player.GetComponent<PlayerMove>().pr = false;
                        }
                        if (transform.position.x > other.transform.position.x && player.GetComponent<PlayerMove>().pr != false)
                        {
                            player.GetComponent<PlayerMove>().pl = false;
                        }
                    }
                }
            }
            else
            {   //상승 하강중
                if (block != 0)
                {
                    if (transform.position.x < other.transform.position.x && player.GetComponent<PlayerMove>().pl != false)
                    {
                        player.GetComponent<PlayerMove>().pr = false;
                    }
                    if (transform.position.x > other.transform.position.x && player.GetComponent<PlayerMove>().pr != false)
                    {
                        player.GetComponent<PlayerMove>().pl = false;
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Land")
        {
            if (block == 0)
            {
                player.GetComponent<PlayerMove>().pr = true;
                player.GetComponent<PlayerMove>().pl = true;
            }
        }
        else if (other.tag == "Block")
        {
            block -= 1;
            if (block == 1)
            {
                if (transform.position.x < other.transform.position.x && player.GetComponent<PlayerMove>().pr == false)
                {
                    player.GetComponent<PlayerMove>().pr = true;
                }
                if (transform.position.x > other.transform.position.x && player.GetComponent<PlayerMove>().pl == false)
                {
                    player.GetComponent<PlayerMove>().pl = true;
                }
            }
            else if (block == 0)
            {
                player.GetComponent<PlayerMove>().pr = true;
                player.GetComponent<PlayerMove>().pl = true;
            }
        }
    }
}
