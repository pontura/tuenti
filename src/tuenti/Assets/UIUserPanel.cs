using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUserPanel : UIPanelScreen
{
    public GameObject avatarBtn;
    public GameObject registered;
    public GameObject register;
    public InputField inputField;
    public InputField inputDniField;
    public Text usernameField;
    public Text starsField;
    public Text levelField;
    public Text ventasField;
    public Text dniField;
    public Text debugField;
    public UIBooks uiBooks;

    public void OnInit()
    {
        debugField.text = "";
        dniField.text = "";
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
        dniField.text = Data.Instance.userData.dni;
        starsField.text = "Puntos: " + Data.Instance.databaseManager.GetTotalStars();
        levelField.text = Data.Instance.userData.GetLevelName();
        ventasField.text = "Ventas: " + Data.Instance.userData.ventas.ToString();
        uiBooks.OnInit();
    }
    public void RegisterClicked()
    {
        string error = "";

        if (inputField.text.Length < 2)
            error = "Ingresa un nombre válido";
        else if (inputDniField.text.Length < 2)
            error = "Ingresa un DNI válido";

        if (error != "")
        { 
            debugField.text = error;
            return;
        }
        Data.Instance.userData.Register(inputField.text, dniField.text);
        Data.Instance.LoadLevel("Game");
        Close();
    }
}
