using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customizer : UIPanelScreen
{
    public CharacterCustomizer characterCustomizer;
    public Image thumb_pantalones;
    public Image thumb_remeras;
    public Image thumb_shoes;

    void Start()
    {
        Events.OnCustomize += OnCustomize;
        Invoke("OnDelayed", 0.1f);
    }
    void OnCustomize(CharacterCustomizer.Types t, int a)
    {
        Invoke("OnDelayed", 0.1f);
    }
    private void OnDelayed()
    {
        int partID = PlayerPrefs.GetInt(CharacterCustomizer.Types.COLOR_PANTAS.ToString(), 0);
        thumb_pantalones.color = Data.Instance.settings.pantalonesColor[partID];

        partID = PlayerPrefs.GetInt(CharacterCustomizer.Types.COLOR_REMES.ToString(), 0);
        thumb_remeras.color = Data.Instance.settings.remerasColor[partID];

        partID = PlayerPrefs.GetInt(CharacterCustomizer.Types.COLOR_ZAPAS.ToString(), 0);
        thumb_shoes.color = Data.Instance.settings.zapasColor[partID];
    }
    public void SetOn()
    {
        Init();
    }
}
