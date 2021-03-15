using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public string[] texts;
    public int tutorialID;
    public Sprite[] sprites;

    void Start()
    {
        tutorialID = PlayerPrefs.GetInt("tutorialID", 0);
    }
    void SetOn()
    {
        if (sprites[tutorialID] != null)
            Events.OnConfirmationImage(texts[tutorialID], sprites[tutorialID], OnDone);
        else
            Events.OnConfirmation(texts[tutorialID], OnDone);
        tutorialID++;
        PlayerPrefs.SetInt("tutorialID", tutorialID);
    }
    void OnDone()
    {
        if (tutorialID == 3 || tutorialID == 5 || tutorialID == 7 || tutorialID == 8 || tutorialID == 10)
            Invoke("SetOn", 0.5f);
    }
    public void OnEnterCity()
    {
        if (tutorialID == 0 || tutorialID == 11)
            Invoke("SetOn", 0.7f);
    }
    public void OnEnterAcademy()
    {
        if (tutorialID == 1) Invoke("SetOn", 0.7f);
    }
    public void OnCursoDone()
    {
        if (tutorialID == 2 && Data.Instance.userData.cursosDone.Count>=2) Invoke("SetOn", 0.7f);
        if (tutorialID == 12 && Data.Instance.userData.cursosDone.Count >= Data.Instance.databaseManager.cursosData.all.Length) Invoke("SetOn", 1f);
    }
    public void OnTestDone()
    {
        if (tutorialID == 4) Invoke("SetOn", 0.7f);
    }
    public void OnVentaDone()
    {
        if (tutorialID == 9) Invoke("SetOn", 0.7f);
    }
    public void OnLevelUp()
    {
        if (tutorialID == 6)
            Invoke("SetOn", 0.7f);
        else
            Events.OnConfirmation("¡Felicitaciones!, ahora sos " + Data.Instance.settings.levels[Data.Instance.userData.level].name, OnDone);
        
    }
}
