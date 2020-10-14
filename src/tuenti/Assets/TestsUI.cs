using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsUI : MonoBehaviour
{
    int id;
    void Start()
    {
        Loop();
    }
    public void GotoGame()
    {
        Data.Instance.LoadLevel("Game");
        GetComponent<TriviaUI>().Init();
    }
    private void Loop()
    {
        if (Data.Instance.databaseManager.allLoaded)
            SetOn();
        else
            Invoke("Loop", 0.1f);
    }
    public void Next()
    {
        id++;
        if (id > Data.Instance.databaseManager.testsData.all.Length - 1)
            GotoGame();
        else
            SetOn();
    }
    void SetOn()
    {
        DatabaseManager.TestData data = Data.Instance.databaseManager.testsData.all[id];
        GetComponent<TriviaUI>().OnInit(data);
    }
}
