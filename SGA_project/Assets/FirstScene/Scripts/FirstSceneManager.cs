using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
    private int videoLenght = 12;

    void Awake() 
    {
        StartCoroutine(StartCounter());
        //Debug.Log("Avake");
    }

    IEnumerator StartCounter() 
    {

        //Debug.Log("bfore while");
        while (videoLenght>0) 
        {

            //Debug.Log("inside while");
            yield return new WaitForSeconds(1);
            videoLenght--;
            //Debug.Log(videoLenght);
        }
        if (videoLenght<=0) 
        {

            //Debug.Log("Load");
            SceneManager.LoadScene("MainRoom");
        }
    }
}
