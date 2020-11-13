using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelScreen : MonoBehaviour
{
    public GameObject panel;
    void Awake()
    {
        panel.SetActive(false);
    }
    public virtual void Init()
    {
        print("init " + panel.gameObject.name);
        panel.SetActive(true);
    }
    public virtual void Close()
    {
        panel.SetActive(false);
    }
}
