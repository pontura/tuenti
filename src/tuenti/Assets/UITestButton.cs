using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestButton : UIButton
{
    public Text field;
    public DatabaseManager.TestData data;

    public void OnInit(DatabaseManager.TestData data)
    {
        this.data = data;
        field.text = data.text;
    }
}
