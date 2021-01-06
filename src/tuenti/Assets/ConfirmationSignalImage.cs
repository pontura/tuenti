using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationSignalImage : UIPanelScreen
{
    public Text field;
    System.Action OnOk;
    public Image image;

    void Start()
    {
        Events.OnConfirmationImage += OnConfirmationImage;
    }
    private void OnDestroy()
    {
        Events.OnConfirmationImage -= OnConfirmationImage;
        Time.timeScale = 1;
    }
    void OnConfirmationImage(string text, Sprite sprite, System.Action OnOk)
    {
        this.OnOk = OnOk;
        field.text = text;
        Init();
        Time.timeScale = 0;
        image.sprite = sprite;
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
