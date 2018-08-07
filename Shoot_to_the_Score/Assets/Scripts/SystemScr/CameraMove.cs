using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private GameObject player;

	void Start () {
        player = GameObject.Find("Player");
	}
	
	void Update () {
        if (player != null)
        {
            Vector3 i;
            i.x = Mathf.Floor(player.transform.position.x / 20.0f) * 20.0f + 10;
            i.y = Mathf.Floor((player.transform.position.y + 3.125f) / 11.25f) * 11.25f + 2.5f;
            i.z = -10;
            transform.position = i;
        }
	}
}
