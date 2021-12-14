using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Variável pelo dano causado pela bomba
    public int damage = 3;

    [SerializeField]
    // Variável que controla se a bomba irá dar dano no player ou enemy
    private bool enemyDamaged;
    public bool playerBomb;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (enemyDamaged && !GameManager.bossShield)
        { 
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TookDamage(damage);
            }
        }
        
        
        if(!enemyDamaged)
        {
            Player player = collision.GetComponent<Player>();
            if(player != null)
            {
                player.TookDamage(damage);
            }
        }

        if (collision.gameObject.CompareTag("Shield") && playerBomb)
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }

    }

}










