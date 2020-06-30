using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public int Speed;
    public Vector2 Player;
    public float Distance;
    public int Damage = 10;
    void Start()
    {
        Speed = 30;
    }
    void Update()
    {
        // Voids

        MoveBullet();
        DestroyBullet();

        // Other

    }
    void MoveBullet()
    {
        transform.Translate(new Vector2(0, -Speed * Time.deltaTime));
    }
    void DestroyBullet()
    {
        Distance = Vector2.Distance(Player, transform.position);
        if (Distance > 15)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Colidir com a parede

        if (other.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        //Acertar o inimigo
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy.vida -= Damage;

            //Destroy Bullet
            Destroy(gameObject);

            //Destroy Enemy
            if (Enemy.vida <= 0)
            {
                Destroy(other.gameObject);

                //Adicionar novamente a vida ao inimigo, se nao, o proximo tiro nos outros, mata com uma bala so
                Enemy.vida = 50;
            }
        }

    }
}
