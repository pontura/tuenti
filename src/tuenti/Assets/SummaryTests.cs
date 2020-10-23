using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryTests : UIPanelScreen
{
    public Text field;
    int correctAnswers;
    public void OnInit()
    {
        Init();
        correctAnswers = GetComponent<TriviaUI>().correctAnswers;
        field.text = "Resultado " + correctAnswers + "/10";
    }
    public void OnReady()
    {
        Data.Instance.databaseManager.GetCursoByID(Data.Instance.userData.curso_active_id).SetScore(correctAnswers);
        GetComponent<TestsUI>().GotoGame();
        Data.Instance.userData.TestDone(Data.Instance.userData.curso_active_id, correctAnswers);
    }
}
