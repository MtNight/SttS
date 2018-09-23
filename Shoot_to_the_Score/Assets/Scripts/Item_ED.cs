﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ED : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Range")
        {
            if (other.transform.parent.gameObject.tag == "Player") {
                other.GetComponent<PlayerBattle>().hp += 100;
                other.transform.parent.gameObject.GetComponent<PlayerMove>().StartCoroutine("ED");
                Destroy(this.gameObject);
            }
        }
    }
}
