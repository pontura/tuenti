﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapZone[] all;
    public int id = 0;
    MapZone mapZone;

    void Start()
    {
        if (Data.Instance.lastScene == "Cursos")
        {
            ChangeRoom(1);
            mapZone.SetAvatarTo(mapZone.cursosPoint);
        } else if( Data.Instance.lastScene == "Tests")
        {
            ChangeRoom(1);
            mapZone.SetAvatarTo(mapZone.testsPoint);
        } else
            ChangeRoom(0);

       
    }
    public void ChangeRoom(int id)
    {
        Data.Instance.lastScene = "Game";
        if (id == 1)
            Data.Instance.userData.ResetCostumersReady();

        this.id = id;
        SetRoom();
        GetComponent<CostumersManager>().Init();
    }
    void SetRoom()
    {
     

        foreach (MapZone mz in all)
            mz.gameObject.SetActive(false);

        mapZone = all[id];
        mapZone.Init();
    }
}
