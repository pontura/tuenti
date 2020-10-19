using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 4;
    public Vector2 limits;


    void Start()
    {
        
    }

    // Update is called once per frame
    public void MoveTo(float x, float y)
    {
        if ((transform.localPosition.x < -limits.x && x<0) || (transform.localPosition.x > limits.x && x > 0))
            x = 0;
        if ((transform.localPosition.y < -limits.y && y < 0) || (transform.localPosition.y > limits.y && y > 0))
            y = 0;

        float _x = transform.localPosition.x + x * speed * Time.deltaTime;
        float _y = transform.localPosition.y + y * speed * Time.deltaTime;
        transform.localPosition = new Vector3(_x, _y, 0);
    }
}
