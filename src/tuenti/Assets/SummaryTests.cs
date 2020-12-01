using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryTests : UIPanelScreen
{
    public Text field;
    int correctAnswers;
    public StarsManager starsManager;

    public void OnInit()
    {
        Init();
        TriviaUI triviaUI = GetComponent<TriviaUI>();
        correctAnswers = triviaUI.correctAnswers;
        int totalAnswers = triviaUI.totalAnswers;
       // field.text = "Resultado " + correctAnswers + "/" + GetComponent<TriviaUI>().totalAnswers;
        starsManager.Calculate(totalAnswers, correctAnswers);
    }
    public void OnReady()
    {
        int starsValue = starsManager.GetValue();
        Data.Instance.databaseManager.GetCursoByID(Data.Instance.userData.curso_active_id).SetScore(starsValue);
        GetComponent<TestsUI>().GotoGame();
        Data.Instance.userData.CheckToUnlockLevel();

        if(starsValue>0)
            Data.Instance.tutorialManager.OnTestDone();
    }
}
