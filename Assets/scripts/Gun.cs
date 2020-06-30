using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public Transform LocalBullet;

    public Text GlockAmmoHUD;
    public Image GlockImageHUD;
    public Text ReloadTxt;

    public float reloadTime = 0.5f;
    public bool PodeAtirar;

    public bool Vivo;

    void Start()
    {
        PodeAtirar = true;
        ReloadTxt.text = "";
    }
    void Update()
    {
        if (Player.TakeGlock == true && Player.Vivo == true)
        {
            Shot();
            HUDGlock();
            ReloadSystem();
        }
    }
    void Shot()
    {
        //Permite ou nao o disparo
        if (Player.Bullets > 0 && Player.Vivo == true)
        {
            if (Input.GetButtonDown("Fire1") && PodeAtirar == true)
            {
                Instantiate(Bullet, new Vector3
                (LocalBullet.position.x,
                 LocalBullet.position.y,
                LocalBullet.position.z),
                LocalBullet.transform.rotation);
                Player.Bullets--;
            }
        }
        if (Player.Bullets <= 0 && Player.Vivo == true)
        {
            Player.Bullets = 0;
            PodeAtirar = false;
        }
    }
    void ReloadSystem()
    {
        if (Input.GetKeyDown(KeyCode.R) && Player.Bullets < 10)
        {
            PodeAtirar = false;
            ReloadTxt.text = "Reloading...";
            //precisa do StartCoroutine pra iniciar o Reload
            StartCoroutine(Reload());
            return;
        }

    }
    void HUDGlock()
    {
        //mostra a glock no slot do HUD
        if (Player.TakeGlock)
        {
            GlockAmmoHUD.text = Player.Bullets.ToString();
            GlockImageHUD.enabled = true;
        }

        else if (Player.TakeGlock == false)
        {
            GlockImageHUD.enabled = false;
        }
    }
    IEnumerator Reload()
    {
        //Espera os segundos do reloadTime
        yield return new WaitForSeconds(reloadTime);
        //Em seguida executa a linha de baixo
        PodeAtirar = true;
        Player.Bullets = 10;
        ReloadTxt.text = "";
    }
}

