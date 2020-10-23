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

    public void Init()
    {
        gameObject.SetActive(true);
        startingPoint.SetActive(false);

        switch(Data.Instance.lastScene)
        {
            case "Tests":
                SetAvatarTo(testsPoint);
                break;
            case "Cursos":
                SetAvatarTo(cursosPoint);
                break;
            default:
                SetAvatarTo(startingPoint);
                break;
        }       
    }
    public void SetAvatarTo(GameObject go)
    {
        if(go != null)
            Game.Instance.character.transform.position = go.transform.position;
    }
}
