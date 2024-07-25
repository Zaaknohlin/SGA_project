using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainManagerHubScene : MonoBehaviour
{
    public Button nextScene;
    public Button previousScene;
    public Button LVLrunningaway;
    public Button quit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGameScene1Scene()
    {
        SceneManager.LoadScene("GameScene1");
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void LoadLVLrunningawayScene()
    {
        SceneManager.LoadScene("LVLrunningaway");
    }

    public void Exit()
    {
        EditorApplication.ExitPlaymode();
    }
}