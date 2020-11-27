using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour
{
    public GameObject startingPoint;
    public GameObject housePoint;
    public GameObject academyPoint;
    public GameObject testsPoint;
    public GameObject cursosPoint;
    public GameObject ventasPoint;
    public GameObject[] gosToArrenge;
    public Vector2 limits;
    public bool isCity;

    private void Start()
    {
        foreach(GameObject go in gosToArrenge)
        {
            Vector3 pos = go.transform.localPosition;
            pos.z = pos.y;
            go.transform.localPosition = pos;
        }
            
    }
    public void Init()
    {
        gameObject.SetActive(true);
        startingPoint.SetActive(false);
        Game.Instance.character.limits = limits;
        if (isCity)
        {
            switch (Data.Instance.lastScene)
            {
                case "Ventas":
                    SetAvatarTo(ventasPoint);
                    break;
                case "Game":
                    SetAvatarTo(academyPoint);
                    break;
                default:
                    SetAvatarTo(startingPoint);
                    break;
            }
        }
        else
        {
            switch (Data.Instance.lastScene)
            {
                case "Tests":
                    SetAvatarTo(testsPoint);
                    break;
                case "Cursos":
                    SetAvatarTo(academyPoint);
                    break;
                default:
                    SetAvatarTo(startingPoint);
                    break;
            }
        }
    }
    public void SetAvatarTo(GameObject go)
    {
        if(go != null)
            Game.Instance.character.transform.position = go.transform.position;
    }
}
