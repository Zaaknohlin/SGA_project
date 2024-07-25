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

    public GameObject pauseScreen;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
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

    void ChangePaused()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}