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
        GameObject.Find("UImanager").GetComponent<UImanage>().scenenum = 2;
        SceneManager.LoadScene("GameScene");
    }
    public void GtoM()
    {
        GameObject.Find("UImanager").GetComponent<UImanage>().scenenum = 1;
        SceneManager.LoadScene("MainMenu");
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
            GameObject.Find("pMoverange").gameObject.SetActive(true);
            //gameObject.SetActive(false);
            yield break;
        }
    }

}
