using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaUI : UIScrollItemsScreen
{
    public Text field;
    TestsUI testUI;
    DatabaseManager.TestData data;
    [HideInInspector] public List<UITriviaButton> all;
    public int correctAnswers;
    bool answered;

    private void Awake()
    {
        testUI = GetComponent<TestsUI>();
    }
    public void OnInit(DatabaseManager.TestData data)
    {
        all.Clear();
        this.data = data;
        Init();
        Reset();
        field.text = data.text;
        foreach (DatabaseManager.AnswerData d in Data.Instance.databaseManager.GetTriviaByTest(data.id))
        {
            UITriviaButton newButton = (UITriviaButton)AddItem();
            newButton.OnInit(d);
            all.Add(newButton);
        }
       
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {
        if (answered)
            return;
        UITriviaButton button = (UITriviaButton)uiButton;
        if (data.type == DatabaseManager.TestData.types.SINGLE)
            UnSelectAll();
        button.Toggle(); 
    }
    void UnSelectAll()
    {
        foreach (UITriviaButton b in all)
            b.SetOff();
    }
    public void Done()
    {
       
        if (answered)
            return;
        answered = true;
        bool hasError = false;
        foreach (UITriviaButton uITriviaButton in all)
        {
            
            if (data.type == DatabaseManager.TestData.types.SINGLE)
            {
                if (uITriviaButton.isOn && uITriviaButton.data.value == 1)
                {
                    uITriviaButton.SetResult(true);
                    correctAnswers++;
                }
                else if (uITriviaButton.data.value == 1)
                {
                    uITriviaButton.SetResult(true);
                }
                else if (uITriviaButton.isOn)
                {
                    uITriviaButton.SetResult(false);
                }
            }
            else {
                if (uITriviaButton.isOn && uITriviaButton.data.value == 0)
                {
                    uITriviaButton.SetResult(false);
                    hasError = true;
                }
                else if (!uITriviaButton.isOn && uITriviaButton.data.value == 1)
                {
                    uITriviaButton.SetResult(true);
                    hasError = true;
                }
                else if (uITriviaButton.isOn && uITriviaButton.data.value == 1)
                {
                    uITriviaButton.SetResult(true);
                }
            }
        }
        if (data.type == DatabaseManager.TestData.types.MULTIPLE)
        {
            if (!hasError)
            {
                correctAnswers++;
                Events.PlaySound("ui", "btn_ok", false);
            }
            else
            {
                Events.PlaySound("ui", "btn_bad", false);
            }
        }
        
        Invoke("Delayed", 2);
    }
    void Delayed()
    {
        testUI.Next();
        answered = false;
    }
}