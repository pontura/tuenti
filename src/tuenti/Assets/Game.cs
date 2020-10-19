using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    static Game mInstance = null;
    public static Game Instance
    {
        get        {   return mInstance; }
    }
    void Awake()
    {
        if (!mInstance)  mInstance = this;
    }
    public void GotoCursos()
    {
        Data.Instance.LoadLevel("Cursos");
    }
    public void GotoTests()
    {
        Data.Instance.LoadLevel("Tests");
    }
    private void Start()
    {
        Data.Instance.GetComponent<Books>().CheckToAddBookToScene();
    }
}
