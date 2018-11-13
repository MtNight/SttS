using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRange : MonoBehaviour {   //Player's moving under block and both side of block

    private int block;
    private GameObject player;
    private Rigidbody2D prigid;

	void Start () {
        block = 0;
        player = GameObject.Find("Player");
        prigid = player.GetComponent<Rigidbody2D>();
	}
	
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player == null)
        {
            player = transform.parent.gameObject;
        }
        if (other.tag == "Block" && player != null)
        {
            block += 1;
            if (prigid.velocity.y <= 0 && transform.position.y - 0.6f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y * 0.5f)
            {
                if (block == 1)
                {
                    player.GetComponent<PlayerMove>().r = true;
                    player.GetComponent<PlayerMove>().l = true;
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
                    if (transform.position.x < other.transform.position.x && player.GetComponent<PlayerMove>().l != false)
                    {
                        player.GetComponent<PlayerMove>().r = false;
                    }
                    else if (transform.position.x > other.transform.position.x && player.GetComponent<PlayerMove>().r != false)
                    {
                        player.GetComponent<PlayerMove>().l = false;
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            block -= 1;
            if (block == 0)
            {
                if (player.GetComponent<PlayerMove>().r == false)
                {
                    player.GetComponent<PlayerMove>().r = true;
                }
                else if (player.GetComponent<PlayerMove>().l == false)
                {
                    player.GetComponent<PlayerMove>().l = true;
                }
            }
        }
    }
}
