using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    static Game mInstance = null;
    public Character character;
    public MapManager mapManager;

    public static Game Instance
    {
        get        {   return mInstance; }
    }
    void Awake()
    {
        if (!mInstance)  mInstance = this;
    }
    private void Start()
    {
        Data.Instance.uiUserPanel.avatarBtn.SetActive(true);
    }
    public void GotoCursos()
    {
        Data.Instance.LoadLevel("Cursos");
    }
    public void GotoTests()
    {
        Data.Instance.LoadLevel("Tests");
    }
}
