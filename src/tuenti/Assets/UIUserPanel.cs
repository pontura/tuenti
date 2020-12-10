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
            SetDebugText(error);
            return;
        }
        Register(inputField.text, inputDniField.text);
        
    }
    string _username;
    string _dni;
    public void Register(string _username, string _dni)
    {
        Data.Instance.databaseManager.OnLogin(_username, _dni, OnLogin);
        this._username = _username;
        this._dni = _dni;        
    }
    void OnLogin(bool success)
    {
        if (success)
        {
            Data.Instance.userData.Register(_username, _dni);
            Data.Instance.LoadLevel("Game");
            Close();
        }
        else
        {
            SetDebugText( "El dni no está registrado en la base" );
        }
    }
    void SetDebugText(string text)
    {
        Invoke("ResetDebug", 3);
        debugField.text = text;
    }
    void ResetDebug()
    {
        debugField.text = "";
    }
    public void OnCustomizer()
    {
        GetComponent<Customizer>().SetOn();
    }
}
