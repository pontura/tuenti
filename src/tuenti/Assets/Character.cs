using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 4;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void MoveTo(float x, float y)
    {
        float _x = transform.localPosition.x + x * speed * Time.deltaTime;
        float _y = transform.localPosition.y + y * speed * Time.deltaTime;
        transform.localPosition = new Vector3(_x, _y, 0);
    }
}
