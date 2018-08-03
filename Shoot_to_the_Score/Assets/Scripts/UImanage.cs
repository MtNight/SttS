using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanage : MonoBehaviour {
    
	void Start () {
		
	}

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update () {
		
	}
}
