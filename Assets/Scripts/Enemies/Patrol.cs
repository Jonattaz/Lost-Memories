using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemy
{
    // Game object que representa o tiro do Patrol
    public GameObject bulletPrefab;

    // Variável que representa a taxa de tiro do Patrol
    public float fireRate;

    // Tranform que representa onde o tiro será spawnado
    public Transform shotSpawner;

    // Variável que controla quando o Patrol irá atirar novamente
    private float nextFire;

    [SerializeField]
    // Váriavel que controla se o patrol será agressivo ou não
    private bool agressive;

    float disToPlayer;

    [SerializeField]
    float agroRange;

    [SerializeField]
    private bool control;

    [SerializeField]
    private bool deathMode;


    private void Start()
    {
        deathMode = false;
        attack = false;
    }

    // Update is called once per frame
    protected override void Update()
    { 
        //Kyogingo

        base.Update();
        // Distance to player
        disToPlayer = Vector2.Distance(transform.position, target.position);

        if (health <= 0)
        {
            anim.SetTrigger("Death");
        }

        if (targetDistance < 0)
        {
            if (!facingRight)
            {
                Flip();
            }
        }
        else
        {
            if (facingRight)
            {
                Flip();
            }
        }

        if (deathMode && !control)
        {
            agressive = true;
        }

        if (attack || agressive && !control) 
        {
            if (deathMode)
            {
                ChasePlayer();
            }
            
            if (deathMode && Time.time > nextFire)
            {
              Shooting();
              nextFire = Time.time + fireRate;
            }
        }

    }

    // Método que controla o tiro
    public void Shooting()
    {
        if (GameManager.offense)
        {
            anim.SetTrigger("Shooting");
            GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
            if (!facingRight)
            {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);

            }

        }
    }


    void ChasePlayer()
    {

        if (GameManager.offense)
        {
            if (transform.position.x < target.position.x)
            {
                // Enemy is to the left side of the player, so move right
                rb.velocity = new Vector2(speed, 0);
                anim.SetFloat("Speed", Mathf.Abs(speed));
            }
            else
            {
                // Enemy is to the right side of the player, so move left
                rb.velocity = new Vector2(-speed, 0);
                anim.SetFloat("Speed", Mathf.Abs(speed));
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cam"))
        {
            attack = true;
        }

        if (collision.CompareTag("Player"))
        {
            deathMode = true;
        }

    }

}











