using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public void Init()
    {
        gameObject.SetActive(true);
    }
    public void OnReady()
    {
        gameObject.SetActive(false);
    }
}
