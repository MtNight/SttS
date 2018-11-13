using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage : MonoBehaviour {

    private bool col;
    private bool act;
    private bool first;
    private GameObject player;
    public GameObject wall;
    public GameObject elev;
    private GameObject boss;
    private Animator anim;

    void Start () {
        col = false;
        act = false;
        first = false;
        player = GameObject.Find("Player");
        boss = GameObject.Find("BOSS");
        anim = this.GetComponent<Animator>();
    }
    
    void Update() {
        if (col == true && player.transform.position.y < -78.95f && player.transform.position.x > 80)
        {
            //if (act == false)
            //{
            //    act = true;
            //    anim.SetBool("in", true);
            //    elev.GetComponent<PlatMove>().act = true;
            //}
        }
        else
        {
            if (act == true)
            {
                act = false;
                anim.SetBool("in", false);
                elev.GetComponent<PlatMove>().act = false;
                elev.transform.position = new Vector3(90.0f, -119.625f, 16.0f);
                boss.gameObject.SetActive(true);
                boss.GetComponent<Boss>().stat = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Range" && other.transform.parent.tag == "Player")
        {
            if (first == false)
            {
                first = true;
                col = true;
                wall.transform.position = new Vector3(97.3f, -110f, 10);
                elev.transform.position = new Vector3(90.0f, -105.625f, 16.0f);
                if (act == false)
                {
                    act = true;
                    anim.SetBool("in", true);
                    elev.GetComponent<PlatMove>().act = true;
                }
            }
        }
    }
}
