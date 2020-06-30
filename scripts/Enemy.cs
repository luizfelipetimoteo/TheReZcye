using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int vida;
    public int vidaValue;
    public Transform  target;
    public float speed;
    public float Distance;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 2;
        vida = 50;
    }
    void Update()
    {
        //Voids
        EnemyMove();

        //Other
        vidaValue = vida;
    }
    void EnemyMove()
    {

        Distance = Vector2.Distance(target.transform.position, this.transform.position);

        //Move in X
        if (target.transform.position.x > this.transform.transform.position.x && Distance < 7)
        {
            transform.Translate(speed*Time.deltaTime,0,0);
        }
        else  if (target.transform.position.x < this.transform.position.x && Distance < 7)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        //Move in Y
        if (target.transform.position.y > this.transform.position.y && Distance < 7)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (target.transform.position.y < this.transform.position.y && Distance < 7)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}