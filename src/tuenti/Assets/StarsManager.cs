using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{

    public GameObject container;
    public Image[] stars;
    int value;

    public int GetValue()
    {
        if (stars[2].fillAmount == 1)
            return 3;
        else if (stars[1].fillAmount == 1)
            return 2;
        else if (stars[0].fillAmount == 1)
            return 1;
        else
            return 0;
    }
    public void Hide()
    {
        container.SetActive(false);
    }
    public void Init(int value)
    {
        container.SetActive(true);
        foreach (Image s in stars)
            s.fillAmount = 0;
        if (value > 0)
            stars[0].fillAmount = 1;
        if (value > 1)
            stars[1].fillAmount = 1;
        if (value > 2)
            stars[2].fillAmount = 1;
    }
    public void Calculate(float total, float qty)
    {
        container.SetActive(true);
        float valuePercent = qty/ total;

        print("valuePercent: " + valuePercent);
  
        if (valuePercent < 0.5f)
            SetStarts(0, 0, 0);
        //else if (valuePercent <= 0.5f)
        //    SetStarts(1, 0, 0);
        else if (valuePercent <= 0.6f)
            SetStarts(1, 0, 0);
        else if (valuePercent <= 0.7f)
            SetStarts(1, 0, 0);
        else if (valuePercent <= 0.8f)
            SetStarts(1, 1, 0);
        else if (valuePercent <= 0.9f)
            SetStarts(1, 1, 0);
        else  
            SetStarts(1, 1, 1);

        print("valuePercent: " + valuePercent + "   total: " + total + "   qty: " + qty);

    }
    void SetStarts(float v1, float v2, float v3)
    {
        stars[0].fillAmount = v1;
        stars[1].fillAmount = v2;
        stars[2].fillAmount = v3;
    }
    
}
