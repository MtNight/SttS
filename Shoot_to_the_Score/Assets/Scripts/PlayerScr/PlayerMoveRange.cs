using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRange : MonoBehaviour {   //Player's moving under block and both side of block

    private GameObject player;
    private Rigidbody2D prigid;

	void Start () {
        player = transform.parent.gameObject;
        prigid = player.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            if (!(prigid.velocity.y <= 0 && transform.position.y - 0.85f > other.transform.position.y + other.GetComponent<BoxCollider2D>().size.y))
            {

                if (prigid.velocity.y > 0 && transform.position.y + 0.9f < other.transform.position.y - other.GetComponent<BoxCollider2D>().size.y)
                {
                    prigid.velocity = Vector3.zero;
                }
                else
                {
                    if (transform.position.x < other.transform.position.x)
                    {
                        player.GetComponent<PlayerMove>().r = false;
                    }
                    else if (transform.position.x > other.transform.position.x)
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
