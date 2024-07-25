
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManagerNightmarecatcher : MonoBehaviour
{
    public Button nextScene;
    public Button previousScene;

    public GameObject pauseScreen;
    private bool isPaused;

    public GameObject gameOverScreen;
    private bool gameIsActive;

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

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nightmare-catcher");
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene("HubScene");
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

    public void ChangeGameOver()
    {
        if (!gameIsActive)
        {
            gameIsActive = true;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (gameIsActive)
        {
            gameIsActive = false;
            gameOverScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}