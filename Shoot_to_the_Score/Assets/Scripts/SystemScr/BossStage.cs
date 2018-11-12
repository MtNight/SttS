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
    private Animator anim;

    void Start () {
        col = false;
        act = false;
        first = false;
        player = GameObject.Find("Player");
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (col == true && player.transform.position.y < -79)
        {
            if (act == false)
            {
                act = true;
                anim.SetBool("in", true);
                elev.GetComponent<PlatMove>().act = true;
            }
        }
        else
        {
            if (act == true)
            {
                act = false;
                anim.SetBool("in", false);
                elev.GetComponent<PlatMove>().act = false;
                elev.transform.position = new Vector3(90.0f, -119.625f, 16.0f);
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
            }
        }
    }
}
