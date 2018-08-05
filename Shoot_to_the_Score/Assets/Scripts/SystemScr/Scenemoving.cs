using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemoving : MonoBehaviour {

	void Start () {
        StartCoroutine("LtoM");
	}

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update () {
		
	}

    IEnumerator LtoM()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("GameScene");   //LoadtoMain -> 임시로 GameScene이동
            GameObject.Find("UImanager").GetComponent<UImanage>().scenenum = 2;
            yield break;
        }
    }
}
