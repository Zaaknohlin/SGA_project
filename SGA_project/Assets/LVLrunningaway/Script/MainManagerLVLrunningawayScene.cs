using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManagerLVLrunningawayScene : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;

    public GameObject pauseScreen;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(Restart);
        mainMenuButton.onClick.AddListener(LoadMainHub);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("LVLrunningaway");
    }

    public void LoadMainHub()
    {
        SceneManager.LoadScene("MainMenu");
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