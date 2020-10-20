using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsUI : MonoBehaviour
{
    int id;
    public List<DatabaseManager.TestData> all;

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
        {
            all = Data.Instance.databaseManager.GetAllTestDataByCurso(Data.Instance.userData.curso_active_id);
            SetOn();
        }
        else
            Invoke("Loop", 0.1f);
    }
    public void Next()
    {
        id++;
        if (id > all.Count - 1)
            GetComponent<SummaryTests>().OnInit();
        else
            SetOn();
    }
    void SetOn()
    {        
        DatabaseManager.TestData data = all[id];
        GetComponent<TriviaUI>().OnInit(data);
    }
    public void ShowOldTests()
    {
        GetComponent<TestsOld>().OnInit();
    }
}
