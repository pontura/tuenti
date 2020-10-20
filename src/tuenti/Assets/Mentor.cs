using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mentor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Game.Instance.GotoCursos();
        }
    }
}
