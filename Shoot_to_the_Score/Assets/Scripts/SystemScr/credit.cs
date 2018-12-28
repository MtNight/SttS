using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credit : MonoBehaviour {

    public bool act;

	void Start () {
        act = false;
	}
	
	void Update () {
        if (act == true && transform.position.y <= -28.75)
        {
            transform.position += 0.5f * Vector3.up * Time.deltaTime;
        }
	}
}
