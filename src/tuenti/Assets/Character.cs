using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 4;
    public Vector2 limits;
    Animator anim;
    public bool walking;
    bool goLeft;

    public SpriteRenderer[] remes;
    public SpriteRenderer[] pantas;
    public SpriteRenderer[] zapas;

    void Awake()
    {
        goLeft = true;
        anim = GetComponent<Animator>();
        Events.OnCustomize += OnCustomize;
        OnCustomize(CharacterCustomizer.Types.COLLARS, 0); //solo fuerza a inicio:
    }
    private void OnDestroy()
    {
        Events.OnCustomize -= OnCustomize;
    }
    void OnCustomize(CharacterCustomizer.Types t , int id)
    {
        Color c_remes = Data.Instance.settings.remerasColor[PlayerPrefs.GetInt(CharacterCustomizer.Types.COLOR_REMES.ToString(), 0)];
        Color c_panta = Data.Instance.settings.pantalonesColor[PlayerPrefs.GetInt(CharacterCustomizer.Types.COLOR_PANTAS.ToString(), 0)];
        Color c_zapa = Data.Instance.settings.zapasColor[PlayerPrefs.GetInt(CharacterCustomizer.Types.COLOR_ZAPAS.ToString(), 0)];

        foreach (SpriteRenderer sr in remes)
            sr.color = c_remes;
        foreach (SpriteRenderer sr in pantas)
            sr.color = c_panta;
        foreach (SpriteRenderer sr in zapas)
            sr.color = c_zapa;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Costumer")
        {
            Costumer c = other.gameObject.GetComponent<Costumer>();
            if (c.isReady)
            {
                Events.OnConfirmation("Ya tengo mi chip Tuenti", null);
            }
            else
            {
                Data.Instance.userData.costumerID = c.id;
                Data.Instance.LoadLevel("Ventas");
            }
        }
    }
}
