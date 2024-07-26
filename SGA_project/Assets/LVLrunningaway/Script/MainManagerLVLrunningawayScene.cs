using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManagerLVLrunningawayScene : MonoBehaviour
{
    public Button nextScene;
    public Button previousScene;
    public Button resumeGame;
    public Button easy;
    public Button medium;
    public Button hard;

    private bool difficultyButtonWasClicled = false;

    public GameObject menuPanel;

    private ObstacleSpawner obstacleSpawnerScript;

    private DataPersistanceManager dataPersistanceManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        obstacleSpawnerScript = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();

        dataPersistanceManagerScript = GameObject.Find("Data Persistance Manager").GetComponent<DataPersistanceManager>();
        dataPersistanceManagerScript.roomChangement = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
            //obstacleSpawnerScript.StopInvoke();
        }
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVLrunningaway");
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene("MainRoom");
    }

    public void Menu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        if (!difficultyButtonWasClicled)
        {
            //obstacleSpawnerScript.StartInvoke(1f, 1f);
        }
        menuPanel.SetActive(false);
        Time.timeScale = 1f;

    }
    public void Easy()
    {
        difficultyButtonWasClicled = true;
        obstacleSpawnerScript.SetDifficulty(1f);
    }

    public void Medium()
    {
        difficultyButtonWasClicled = true;
        obstacleSpawnerScript.SetDifficulty(0.6f);
    }

    public void Hard()
    {
        difficultyButtonWasClicled = true;
        obstacleSpawnerScript.SetDifficulty(0.3f);
    }
}