using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SpriteRenderer PSR;
    public Sprite DeadPlayer;

    //PlayerStatus
    public static int speed;
    public static int Bullets;
    public static Animator Panim;
    public bool Correr;
    public static bool Vivo;

    //HUD
    public Image vidaHUD;
    public Image coleteHUD;
    public static bool temColete;
    public static bool TakeGlock;
    public Image StaminaIMG;


    void Start()
    {
        PSR = GetComponent<SpriteRenderer>();

        Vivo = true;
        Bullets = 10;
        speed = 4;
        temColete = false;
        coleteHUD.fillAmount = 0f;

        Panim = GetComponent<Animator>();

    }
    void Update()
    {

        // Voids
        Move();
        GunManager();
        ArmorSystem();
        Die();

        //Other

    }
    void Move()
    {

        if (Input.GetKey(KeyCode.W) && Vivo == true)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        //Correr
        if (Input.GetKey(KeyCode.LeftShift) && Vivo == true)
        {
            Correr = true;
            StaminaIMG.fillAmount -= 0.01f;
            speed = 6;
        }
        else
        {
            Correr = false;
            speed = 4;
        }

        if (Correr == false)
        {
            StaminaIMG.fillAmount += 0.0050f;
        }
        if (StaminaIMG.fillAmount == 0)
        {
            speed = 4;
        }

    }
    void GunManager()
    {
        //Muda a animacao do player pra Com ou Sem arma
        if (TakeGlock == true)
        {
            Panim.SetBool("Glock", true);
            Panim.SetBool("IDLE", false);
        }
        else if (TakeGlock != false)
        {
            Panim.SetBool("Glock", false);
            Panim.SetBool("IDLE", true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //tira vida colete
            if (temColete == true)
            {
                coleteHUD.fillAmount -= 0.03f;
            }
            //tira vida da vida
            if (temColete == false)
            {
                vidaHUD.fillAmount -= 0.01f;
            }
        }
    }
    void ArmorSystem()
    {
        //verifica se pode ter colete ou nao
        if (coleteHUD.fillAmount >= 1)
        {
            temColete = true;
        }
        if (coleteHUD.fillAmount <= 0)
        {
            temColete = false;
        }
    }
    void Die()
    {
        //morte
        if (vidaHUD.fillAmount <= 0)
        {
            vidaHUD.fillAmount = 0;
            Vivo = false;

            //PSR.sprite = DeadPlayer;
        }
    }
}

