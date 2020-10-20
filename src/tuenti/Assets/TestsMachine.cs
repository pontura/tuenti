using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestsMachine : MonoBehaviour
{
    bool isOff;
    private void Start()
    {
      
        if (Data.Instance.userData.curso_id == 0)
            isOff = true;
        if(isOff)
        {
            Color c = Color.white;
            c.a = 0.5f;
            GetComponentInChildren<SpriteRenderer>().color = c;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isOff)
            return;

        if (other.tag == "Player")
        {
            Data.Instance.userData.curso_active_id = Data.Instance.userData.curso_id;
            Data.Instance.LoadLevel("Tests");
        }
    }
}
