using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestButton : UIButton
{
    public Text field;
    public DatabaseManager.CursoData data;

    public void OnInit(DatabaseManager.CursoData data)
    {
        this.data = data;
        field.text = data.id + " - Score: " + data.test_score;
    }
}
