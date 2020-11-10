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

        List<DatabaseManager.TestData> arr =  Data.Instance.databaseManager.GetAllTestDataByCurso(data.id);
        float total = arr.Count;
        float score = cursoData.test_score;
        GetComponent<StarsManager>().Init(testCanBeDone, total, score);

        bool isLocked = Data.Instance.databaseManager.IsCursoLocked(data.id);
        if (forceActive)
            isLocked = false;

        locked.SetActive(isLocked);

        if (isLocked)
            GetComponent<Button>().interactable = false;

    }
}
