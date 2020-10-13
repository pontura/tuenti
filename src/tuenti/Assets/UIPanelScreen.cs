using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelScreen : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }
    public virtual void Init()
    {
        panel.SetActive(true);
    }
    public virtual void Close()
    {
        panel.SetActive(false);
    }
}
