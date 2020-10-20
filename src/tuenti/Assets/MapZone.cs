using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour
{
    public GameObject startingPoint;

    public void Init()
    {
        gameObject.SetActive(true);
        startingPoint.SetActive(false);
        Game.Instance.character.transform.position = startingPoint.transform.position;
    }
}
