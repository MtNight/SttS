using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private float Speed;
    private Vector3 moveArrow;
    private Vector3 dir;

	void Start () {
        Speed = 3.0f;
        moveArrow = Vector3.zero;
    }
	
	void Update () {
        moveArrow = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveArrow = Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveArrow = Vector3.right;
        }
        transform.position += moveArrow * Speed * Time.deltaTime;
	}
}
