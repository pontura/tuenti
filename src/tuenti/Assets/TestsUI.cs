using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsUI : MonoBehaviour
{
    int id;
    public List<DatabaseManager.TestData> all;
    DatabaseManager.CursoData actualCurso;

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
            SetCursoByID(Data.Instance.userData.curso_active_id);
            if (actualCurso.test_score > 0)
                ShowOldTests();
            else
                SetOn();
        }
        else
            Invoke("Loop", 0.1f);
    }
    public void OpenOldCurso(int curso_id)
    {
        SetCursoByID(curso_id);
        SetOn();
    }
    void SetCursoByID(int curso_id)
    {
        all = Data.Instance.databaseManager.GetAllTestDataByCurso(curso_id);
        actualCurso = Data.Instance.databaseManager.GetCursoByID(curso_id);
        print("actualCurso " + actualCurso.id + " score: " + actualCurso.test_score);
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
