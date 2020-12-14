using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    Animation anim;
    public GameObject pauseSignal;

    private void Start()
    {
        pauseSignal.SetActive(false);
        anim = GetComponent<Animation>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pauseSignal.SetActive(true);
            anim[anim.clip.name].normalizedSpeed = 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pauseSignal.SetActive(false);
            anim[anim.clip.name].speed = 1;
        }
    }
    public void Init()
    {
        gameObject.SetActive(true);
    }
    public void OnReady()
    {
        gameObject.SetActive(false);
    }
}
