using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    private int points = 0;
    private int lives = 3;

    private GameObject player;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        pointsText.text = "Score: " + points;
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int value) 
    {
        points+=value;
        if (points < 0)
        {

            pointsText.text = "Score: 0" ;
            Time.timeScale = 0f;
            return;
            //After merge - activate canvas
        }
        //Find text on the canvas and display

        pointsText.text = "Score: " + points;
    }

    public void AddLive(int value) 
    {
        lives += value;
        if (lives<=0)
        {
            Destroy(player);
            Time.timeScale = 0f;
            livesText.text = "Lives: " + lives;
            //After merge - activate canvas
        }

        livesText.text = "Lives: " + lives;
    }
}
