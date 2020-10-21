using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{
    public Text field;
    void Awake()
    {
        Events.DatabaseLoaded += DatabaseLoaded;
        field.text = "CARGANDO...";
    }
    void OnDestroy()
    {
        Events.DatabaseLoaded -= DatabaseLoaded;
    }
    void DatabaseLoaded()
    {
        if (Data.Instance.userData.IsLogged())
            Data.Instance.LoadLevel("Game");
        else
            Data.Instance.uiUserPanel.OnInit();
    }
}
