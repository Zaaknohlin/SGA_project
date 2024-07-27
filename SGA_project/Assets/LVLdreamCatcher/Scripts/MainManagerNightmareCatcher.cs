
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManagerNightmarecatcher : MonoBehaviour
{
    public Button nextScene;
    public Button previousScene;
    public Button resumeGame;
    public Button easy;
    public Button medium;
    public Button hard;

    private bool difficultyButtonWasClicled = false;

    public GameObject menuPanel;

    private Instantiation instantiationScript;


    private DataPersistanceManager dataPersistanceManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        instantiationScript = GameObject.Find("Game Manager").GetComponent<Instantiation>();

        dataPersistanceManagerScript = GameObject.Find("Data Persistance Manager").GetComponent<DataPersistanceManager>();
        dataPersistanceManagerScript.roomChangement = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
            instantiationScript.StopInvoke();
        }
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVLdreamCatcher");
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
            instantiationScript.StartInvoke(1f, 1f);
        }
        menuPanel.SetActive(false);
        Time.timeScale = 1f;

    }
    public void Easy() 
    {
        difficultyButtonWasClicled = true;
        instantiationScript.StartInvoke(1f, 1f);
    }

    public void Medium()
    {
        difficultyButtonWasClicled = true;
        instantiationScript.StartInvoke(1f, 0.7f);
    }

    public void Hard()
    {
        difficultyButtonWasClicled = true;
        instantiationScript.StartInvoke(0.7f, 0.5f);
    }
}