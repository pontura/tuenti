using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestButton : UIButton
{
    public GameObject locked;
    public Text field;
    public DatabaseManager.CursoData data;
    StarsManager starsManager;

    public void OnInit(DatabaseManager.CursoData data, bool forceActive)
    {
        this.data = data;
        //field.text = data.id + " - Score: " + data.test_score;
        DatabaseManager.CursoData cursoData = Data.Instance.databaseManager.GetCursoByID(data.id);
        field.text = cursoData.nombre;
        bool testCanBeDone = false;
        if (cursoData.test_score > 0)
            testCanBeDone = true;

        GetComponent<StarsManager>().Init(testCanBeDone, cursoData.test_score);

        bool isLocked = Data.Instance.databaseManager.IsCursoLocked(data.id);
        if (forceActive)
            isLocked = false;

        locked.SetActive(isLocked);

        if (isLocked)
            GetComponent<Button>().interactable = false;

    }
}
