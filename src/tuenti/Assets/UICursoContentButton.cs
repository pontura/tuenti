using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursoContentButton : UIButton
{
    public Text field;
    public DatabaseManager.MultiplechoiceData data;
    public void OnInit(DatabaseManager.MultiplechoiceData data)
    {
        this.data = data;
        field.text = data.text;
    }
}
