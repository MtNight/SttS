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
    public void MtoG()
    {
        SceneManager.LoadScene("GameScene");
        GameObject.Find("UImanager").GetComponent<UImanage>().scenenum = 2;
    }
    public void GtoM()
    {
        SceneManager.LoadScene("MainMenu");
        GameObject.Find("UImanager").GetComponent<UImanage>().scenenum = 1;
    }
    public void Exit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    IEnumerator LtoM()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("MainMenu");
            GameObject.Find("UImanager").GetComponent<UImanage>().scenenum = 1;
            yield break;
        }
    }

}
