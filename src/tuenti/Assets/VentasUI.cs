using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentasUI : MonoBehaviour
{
    public int totalScore;
    public int score;

    void Start()
    {
        GetComponent<CursoContentUI>().Init(CursoContentUI.types.VENTA);
    }
    public void OnReady(bool success)
    {
        Data.Instance.userData.VentaDone(success);
        Data.Instance.LoadLevel("Game");
        if (success)
            Events.OnConfirmation("¡Venta Exitosa!", null);
    }
}
