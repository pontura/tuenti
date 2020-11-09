using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumersManager : MonoBehaviour
{
    public List<Costumer> all;

    void Start()
    {

        foreach (Costumer c in all)
        {
            if(c.isActiveAndEnabled)
                c.Init();
        }
    }
}
