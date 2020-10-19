using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraIngame : MonoBehaviour
{
    public Character character;
    public Vector2 limits;

    void Update()
    {
        Vector3 to = character.transform.position;
        to.z = -10;
        if (to.x < -limits.x)
            to.x = -limits.x;
        else if (to.x > limits.x)
            to.x = limits.x;
        if (to.y < -limits.y)
            to.y = -limits.y;
        else if (to.y > limits.y)
            to.y = limits.y;
        transform.position = Vector3.Lerp(transform.position, to, 0.1f);
    }
}
