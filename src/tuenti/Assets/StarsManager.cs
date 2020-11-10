using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{

    public GameObject container;
    public Image[] stars;

    public void Init(bool isOn, float total, float qty)
    {
        container.SetActive(isOn);
        float valuePercent = qty/ total;

        print("valuePercent: " + valuePercent);


  
        if (valuePercent < 0.5f)
            SetStarts(0, 0, 0);
        else if (valuePercent <= 0.5f)
            SetStarts(0.5f, 0, 0);
        else if (valuePercent <= 0.6f)
            SetStarts(1, 0, 0);
        else if (valuePercent <= 0.7f)
            SetStarts(1, 0.5f, 0);
        else if (valuePercent <= 0.8f)
            SetStarts(1, 1, 0);
        else if (valuePercent <= 0.9f)
            SetStarts(1, 1, 0.5f);
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
