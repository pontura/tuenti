using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    bool isOn;
    private void Start()
    {
        if (Data.Instance.userData.curso_id >= Data.Instance.databaseManager.cursosData.all.Length)
            isOn = true;
    }
    private void OnTriggerEnter(Collider other)
    {       
        if (other.tag == "Player")
        {
            if (isOn)
                return;
            else
                Events.OnConfirmation("Cuando termines todos los test, te tomaré la prueba final", null);
        }
    }
}
