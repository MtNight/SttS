using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    private int tnum;

	void Start () {
        if (transform.position.x == 26 && transform.position.y == -0.5)
        {
            tnum = 0;
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
                }
                
            }
        }
    }
}
