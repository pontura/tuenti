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
            print("__________" + d);
            UITriviaButton newButton = (UITriviaButton)AddItem();
            newButton.OnInit(d);
            all.Add(newButton);
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton)
    {
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
        print("next");
        testUI.Next();
    }
}