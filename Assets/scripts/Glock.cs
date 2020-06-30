using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Glock : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //Diz se o player esta ou nao com a glock na mao
                Player.TakeGlock = true;

                Destroy(gameObject);

                //Debuga se o player ta com alguma arma ou nao
                GunVerify();
            }
        }
        else
        {
            //Diz se o player esta ou nao com a glock na mao
            Player.TakeGlock = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GunVerify();
    }
    private void GunVerify()
    {
        if (Player.TakeGlock == true)
        {
            print("Glock esta em uso");
        }
        else
        {
            print("Nenhuma arma selecionada");
        }
    }
}
