using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script attached to room object

public class RoomArrangement : MonoBehaviour
{
    public bool canChangeRoom=false;

    //////0-dirty / 1-medium / 2-clean
    private int roomState = 0;

    private DataPersistanceManager dataPersistanceManagerScript;

    private void Awake()
    {
        //Search for 
        dataPersistanceManagerScript = GameObject.Find("Data Persistance Manager").GetComponent<DataPersistanceManager>();
        if (dataPersistanceManagerScript.roomChangementRunningAway)
        {
            roomState += 1;
        }
        if (dataPersistanceManagerScript.roomChangementDreamCatcher)
        {
            roomState += 1;
        }
        ChangeRoomDecoration();
    }

    public void ChangeRoomDecoration() 
    {
        switch (roomState)
        {
            case 0:
                //Trigger changement
                roomState = 1;
                break;
            case 1:
                //Trigger changement
                roomState = 2;
                break;
            default:
                break;
        }
    }
}
