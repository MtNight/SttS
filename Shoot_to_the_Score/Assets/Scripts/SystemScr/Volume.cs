using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    private Slider me;
    private float vol;

	// Use this for initialization
	void Start () {
        me = GetComponent<Slider>();
        me.maxValue = 1;
        me.minValue = 0;
        me.value = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        vol = GameObject.Find("UImanager").GetComponent<AudioSource>().volume;
        me.value = vol;
	}

    public void VolChange(float ch)

    {
        me.value = ch;
        GameObject.Find("UImanager").GetComponent<AudioSource>().volume = me.value;
    }
}
