using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManagerGameScene1 : MonoBehaviour
{
    public Button nextScene;
    public Button previousScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("GameScene1");
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene("HubScene");
    }
}