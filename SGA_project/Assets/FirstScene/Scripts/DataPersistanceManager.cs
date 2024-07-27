using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager Instance;

    public bool roomChangement = false;

    private void Awake()
    {


        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
