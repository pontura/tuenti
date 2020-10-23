using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUserPanel : UIPanelScreen
{
  
    public GameObject registered;
    public GameObject register;
    public InputField inputField;

    public Text usernameField;
    public Text starsField;
    public Text levelField;

    public UIBooks uiBooks;

    public void OnInit()
    {
        Init();

        registered.SetActive(false);
        register.SetActive(false);

        if (Data.Instance.userData.IsLogged())
        {
            registered.SetActive(true);            
            InitRegistered();
        }
        else
            register.SetActive(true);       
        
    }
    void InitRegistered()
    {
        usernameField.text = Data.Instance.userData.username;
        starsField.text = "Puntos: " + Data.Instance.databaseManager.GetTotalStars();
        levelField.text = Data.Instance.userData.GetLevelName();
        uiBooks.OnInit();
    }
    public void RegisterClicked()
    {
        if (inputField.text.Length < 2)
            return;

        Data.Instance.userData.Register(inputField.text);
        Data.Instance.LoadLevel("Game");
        Close();
    }
}
