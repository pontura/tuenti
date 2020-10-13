using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
    static Data mInstance = null;
    [HideInInspector] public string newScene;
    public DatabaseManager databaseManager;
    public UserData userData;

    public static Data Instance
    {
        get
        {
            return mInstance;
        }
    }
    public void LoadLevel(string aLevelName)
    {
        this.newScene = aLevelName;
         SceneManager.LoadScene(newScene);
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;

        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        databaseManager = GetComponent<DatabaseManager>();
        userData = GetComponent<UserData>();
    }
    private void Start()
    {
        databaseManager.Init();
    }
}
