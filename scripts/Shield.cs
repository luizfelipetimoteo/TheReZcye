using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Image colete;
    void OnTriggerStay2D(Collider2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player") && Player.temColete == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                colete.fillAmount += 1;
                Destroy(gameObject);
            }
        }
    }
}