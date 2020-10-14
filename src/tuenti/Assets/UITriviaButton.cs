using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITriviaButton : UIButton
{
    public Text field;
    public DatabaseManager.AnswerData data;

    public void OnInit(DatabaseManager.AnswerData data)
    {
        this.data = data;
        field.text = data.text;
    }
}
