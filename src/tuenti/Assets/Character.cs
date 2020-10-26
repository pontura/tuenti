using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 4;
    public Vector2 limits;
    Animator anim;
    bool walking;
    bool goLeft;

    void Start()
    {
        goLeft = true;
        anim = GetComponent<Animator>();
    }
    public void Idle()
    {
        anim.Play("idle");
        walking = false;
    }
    public void Walk()
    {
        anim.Play("walk");
        walking = true;
    }
    public void MoveTo(float x, float y)
    {
        if ((transform.localPosition.x < -limits.x && x<0) || (transform.localPosition.x > limits.x && x > 0))
            x = 0;
        if ((transform.localPosition.y < -limits.y && y < 0) || (transform.localPosition.y > limits.y && y > 0))
            y = 0;
        if (x == 0 && y == 0 && walking)
            Idle();
        else if (x != 0 && y != 0 && !walking)
            Walk();
        if(goLeft && x<0)
        {
            goLeft = false;
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (!goLeft && x > 0)
        {
            goLeft = true;
            transform.localScale = new Vector3(1, 1, 1);
        }

        float _x = transform.localPosition.x + x * speed * Time.deltaTime;
        float _y = transform.localPosition.y + y * speed * Time.deltaTime;
        transform.localPosition = new Vector3(_x, _y, _y);
    }
}
