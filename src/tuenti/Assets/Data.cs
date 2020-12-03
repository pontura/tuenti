using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
    static Data mInstance = null;
    public string lastScene;
    [HideInInspector] public string newScene;
    public DatabaseManager databaseManager;
    public UserData userData;
    public TextsManager textsManager;
    public UIUserPanel uiUserPanel;
    public Settings settings;
    public Intro intro;
    public TutorialManager tutorialManager;

    public static Data Instance
    {
        get
        {
            return mInstance;
        }
    }
    public void LoadLevel(string aLevelName)
    {       
        lastScene = SceneManager.GetActiveScene().name;
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
        tutorialManager = GetComponent<TutorialManager>();
    }
    private void Start()
    {
        intro.Init();
        databaseManager.Init();
    }
    public void RestartApp()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
