using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    private int tnum;

	void Start () {
        if (transform.position.x == 36 && transform.position.y == -20.5)
        {
            tnum = 0;
        }
        else if (transform.position.x == 36 && transform.position.y == -41)
        {
            tnum = 1;
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
                switch (tnum)
                {
                    case 0: other.transform.parent.gameObject.transform.position = new Vector3(3, -45, 5); break;
                    case 1: other.transform.parent.gameObject.transform.position = new Vector3(3, -111f, 5); break;
                }
                
            }
        }
    }
}
