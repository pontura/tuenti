using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapZone[] all;
    public int id = 0;

    void Start()
    {
        if (Data.Instance.lastScene == "Cursos" || Data.Instance.lastScene == "Tests")
            id = 1;
        SetRoom();
    }
    public void ChangeRoom(int id)
    {
        this.id = id;
        SetRoom();
    }
    void SetRoom()
    {
        foreach (MapZone mz in all)
            mz.gameObject.SetActive(false);

        all[id].Init();
    }
}
