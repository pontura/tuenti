﻿using System.Collections;
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
        if (success)
            Data.Instance.userData.costumersReady[Data.Instance.userData.costumerID] = 1;

        Data.Instance.userData.VentaDone(success);
        Data.Instance.LoadLevel("Game");
        if (success)
            Events.OnConfirmation("¡Haz hecho una venta!", null);
    }
}
