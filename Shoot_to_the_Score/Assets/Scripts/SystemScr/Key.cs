using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public int knum;
    private GameObject trigger;
    private Animator anim;

    void Start () {
        if (transform.position.x == 59 && transform.position.y == -111)
        {
            knum = 0;
            trigger = GameObject.Find("Teleport1-1");
        }
        else if (transform.position.x == 2 && transform.position.y == -99)
        {
            knum = 1;
            trigger = GameObject.Find("doorspr");
        }
        else if (transform.position.x == 2 && transform.position.y == -86.0f)
        {
            knum = 2;
            trigger = GameObject.Find("Teleport1-4");
        }
        else if (transform.position.x == 59.45f && transform.position.y == -100f)
        {
            knum = 3;  //lever
            anim = this.GetComponent<Animator>();
            trigger = GameObject.Find("DCGs3-1");
        }
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Range")
        {
            if (other.transform.parent.gameObject.tag == "Player")
            {
                switch (knum)
                {
                    case 0: trigger.GetComponent<Teleport>().active = true; Destroy(this.gameObject); break;
                    case 1:
                        {
                            Vector3 i = trigger.transform.parent.gameObject.transform.position;
                            i.x += 100;
                            trigger.transform.parent.gameObject.transform.position = i;
                            i = trigger.transform.position;
                            i.x -= 100;
                            trigger.transform.localScale = new Vector3(3.9f, 0.26f, 1);
                            trigger.transform.position = i;
                            Destroy(this.gameObject);
                            break;
                        }
                    case 2: trigger.GetComponent<Teleport>().active = true; Destroy(this.gameObject); break;
                    case 3: {
                            anim.SetBool("act", true);
                            trigger.transform.parent.GetComponent<Teleport>().active = true;
                            trigger.GetComponent<Animator>().SetBool("open", true);
                            break;
                        } 
                }
            }
        }
    }
}
