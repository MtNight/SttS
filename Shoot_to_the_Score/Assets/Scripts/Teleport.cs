using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public int tnum;
    public bool use;
    public bool active;

	void Start () {
        use = false;
        if (transform.position.x == 36 && transform.position.y == -20.5)
        {
            tnum = 0;
            active = true;
        }
        else if (transform.position.x == 37.8f && transform.position.y == -40.5f)
        {
            tnum = 1;
            active = true;
        }
        else if (transform.position.x == 26.2f && transform.position.y == -113.0f)
        {
            tnum = 2;
            active = false;
        }
        else if (transform.position.x == 5.3f && transform.position.y == -68.0f)
        {
            tnum = 3;
            active = true;
        }
        else if (transform.position.x == 23.3f && transform.position.y == -101.75f)
        {
            tnum = 4;
            active = false;
        }
        else if (transform.position.x == 50.1f && transform.position.y == -90.5f)
        {
            tnum = 5;
            active = false;
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
                if (active == true)
                {
                    switch (tnum)
                    {
                        case 0: other.transform.parent.gameObject.transform.position = new Vector3(3, -45, 5); use = true; break;
                        case 1: other.transform.parent.gameObject.transform.position = new Vector3(3, -111, 5); use = true; break;
                        case 2: other.transform.parent.gameObject.transform.position = new Vector3(3, -77.25f, 5); use = true; break;
                        case 3: other.transform.parent.gameObject.transform.position = new Vector3(27, -99.75f, 5); use = true; break;
                        case 4: other.transform.parent.gameObject.transform.position = new Vector3(23, -90.5f, 5); use = true; break;
                        case 5: other.transform.parent.gameObject.transform.position = new Vector3(50, -79.25f, 5); use = true; break;
                    }
                }
            }
        }
    }
}
