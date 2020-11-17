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

        bool isReady = Data.Instance.userData.IsCursoDone(data.id);

        if (isReady)
            GetComponent<StarsManager>().Init(cursoData.test_score);
        else
            GetComponent<StarsManager>().Hide();
        
        if (forceActive)  isReady = true;

        locked.SetActive(!isReady);

        if (!isReady)
            GetComponent<Button>().interactable = false;

    }
}
