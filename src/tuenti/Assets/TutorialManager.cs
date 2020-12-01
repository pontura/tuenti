using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public string[] texts;
    public int tutorialID;

    void Start()
    {
        tutorialID = PlayerPrefs.GetInt("tutorialID", 0);
    }
    void SetOn()
    {       
        Events.OnConfirmation(texts[tutorialID], OnDone);
        tutorialID++;
        PlayerPrefs.SetInt("tutorialID", tutorialID);
    }
    void OnDone()
    {
        if (tutorialID == 3 || tutorialID == 5 || tutorialID == 7)
            Invoke("SetOn", 0.5f);
    }
    public void OnEnterCity()
    {
        if (tutorialID == 0 || tutorialID == 6) Invoke("SetOn", 1f);
    }
    public void OnEnterAcademy()
    {
        if (tutorialID == 1) Invoke("SetOn", 1f);
    }
    public void OnCursoDone()
    {
        if (tutorialID == 2) Invoke("SetOn", 1f);
    }
    public void OnTestDone()
    {
        if (tutorialID == 4) Invoke("SetOn", 1f);
    }
    public void OnVentaDone()
    {
        if (tutorialID == 8) Invoke("SetOn", 1f);
    }
    public void OnLevelUp()
    {
        if (tutorialID == 9) Invoke("SetOn", 1f);
    }
}
