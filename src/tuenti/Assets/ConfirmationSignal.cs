using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationSignal : UIPanelScreen
{
    public Text field;
    System.Action OnOk;

    void Awake()
    {
        Events.OnConfirmation += OnConfirmation;
    }
    private void OnDestroy()
    {
        Events.OnConfirmation -= OnConfirmation;
        Time.timeScale = 1;
    }
    void OnConfirmation(string text, System.Action OnOk)
    {
        this.OnOk = OnOk;
        field.text = text;
        Init();
        Time.timeScale = 0;
    }
    public void OnOKClicked()
    {
        if (this.OnOk != null)
            OnOk();
        Close();
    }
    public override void Close()
    {
        base.Close();
        Time.timeScale = 1;
    }
}
