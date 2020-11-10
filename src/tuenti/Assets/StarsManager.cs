using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{

    public GameObject container;
    public Image[] stars;

    public void Init(bool isOn, int qty = 0)
    {
        container.SetActive(isOn);

        for (int a = 0; a<3; a++)
        {
            if (a < qty)
                stars[a].fillAmount = 1;
        }
    }
}
