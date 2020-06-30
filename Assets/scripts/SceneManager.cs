using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Animator Start;
    public Animator Fase1;

    public void StartButton()
    {
        Start.SetBool("ApertouStart", true);
        Fase1.SetBool("DesceStart", true);
    }
    public void StartScene()
    {
        //Carregar cena
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
