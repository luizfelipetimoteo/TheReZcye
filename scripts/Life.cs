using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Image vidaIMG;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && vidaIMG.fillAmount < 1f)
            {
                vidaIMG.fillAmount = 1f;
                Destroy(gameObject);
            }
        }
    }
}