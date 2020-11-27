using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costumer : Character
{
    public int id;
    public int pathID;
    public Vector2[] paths;
    Vector2 dest;
    public bool isReady;
    public SpriteRenderer[] colorizable;

    public void Init()
    {
        Loop();
    }
    public void SetState(bool isReady)
    {
        this.isReady = isReady;
        if(isReady)
        {
            foreach (SpriteRenderer a in colorizable)
                a.color = Data.Instance.settings.costumerDoneColor;
        }
        else
        {
            foreach (SpriteRenderer a in colorizable)
                a.color = Data.Instance.settings.costumerIdleColor;
        }
    }
    void Loop()
    {
        int r = Random.Range(0, 10);
        if(r<5 && !walking)
            WalkToDest();
        Invoke("Loop", 2);
    }
    public void WalkToDest()
    {
        pathID++;
        if (pathID > paths.Length-1)
            pathID = 0;
        dest = paths[pathID];
        Walk();
    }
    private void Update()
    {
        if (!walking)
            return;

        Vector3 pos = transform.position;

        float dist_x = Mathf.Abs(pos.x - dest.x);
        float dist_y = Mathf.Abs(pos.y - dest.y);

        if (dist_x < 0.1f && dist_y < 0.1f)
            Idle();

        float _x = 0;
        float _y = 0;
        if (dist_x > 0.1f)
        {
            if (pos.x < dest.x)
                _x = 0.25f;
            else if (pos.x > dest.x)
                _x = -0.25f;
        }
        if (dist_y > 0.1f)
        {
            if (pos.y < dest.y)
                _y = 0.25f;
            else if (pos.x > dest.y)
                _y = -0.25f;
        }
        MoveTo(_x, _y);
    }
}
