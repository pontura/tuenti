using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaUI : UIScrollItemsScreen
{
    public Text field;
    TestsUI testUI;

    private void Awake()
    {
        testUI = GetComponent<TestsUI>();
    }
    public void OnInit(DatabaseManager.TestData data)
    {
        Init();
        Reset();
        field.text = data.text;
        foreach (DatabaseManager.AnswerData d in Data.Instance.databaseManager.GetTriviaByTest(data.id))
        {
            print("__________" + d);
            UITriviaButton newButton = (UITriviaButton)AddItem();
            newButton.OnInit(d);
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {
        UITriviaButton button = (UITriviaButton)uiButton;
        print("next");
        testUI.Next();
    }
}