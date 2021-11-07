using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    // Game object que representa o tiro do Patrol
    public GameObject bulletPrefab;

    [SerializeField]
    // Variável que armazena o gameObject dos lasers
    GameObject Lasers;

    // Variável que representa a taxa de tiro do Patrol
    public float fireRate;

    // Tranform que representa onde o tiro será spawnado
    public Transform shotSpawner;

    // Variável que controla quando o Patrol irá atirar novamente
    private float nextFire;

    // Váriavel que armazena o rigidbody da bomba
    public Rigidbody2D bombRb;

    [SerializeField]
    // Variável que representa o objeto do escudo
    GameObject shield;

    [SerializeField]
    // Musica que toca na bossBattle
    private AudioClip bossSoundtrack;

    // Modo de ataque do boss. False = BerserkMode. True = pistola e granada
    bool attackMode;

    [SerializeField]
    // Tempo
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(bossSoundtrack);
        attackMode = true;
        timer = 30;
    }

    // Update is called once per frame
    protected override void Update()
    {
       timer -= 1 * Time.deltaTime; 
        base.Update();
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


        if (Mathf.Abs(targetDistance) < attackDistance && Time.time > nextFire && attackMode)
        {
            //anim.SetTrigger("Shooting");
            if (health <= 100 && health > 100 * 0.5)
            {
                Shooting();
            }
            else if (health <= 100 * 0.5)
            {
                Bomb();
            }

            nextFire = Time.time + fireRate;
        }

        if (health <= 100 * 0.3 && timer <= 0)
        {
            StartCoroutine(BerserkMode());
            timer = 60;
            
        }
    }


    // Método que controla o tiro
    public void Shooting()
    {
        GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        if (!facingRight)
        {
            tempBullet.transform.eulerAngles = new Vector3(0, 0, 180);

        }
    }

    public void Bomb()
    {

        Rigidbody2D tempBomb = Instantiate(bombRb, shotSpawner.position, shotSpawner.rotation);
        if (facingRight)
        {
            tempBomb.AddForce(new Vector2(8, 10), ForceMode2D.Impulse);
        }
        else if (!facingRight)
        {
            tempBomb.AddForce(new Vector2(-8, 10), ForceMode2D.Impulse);
            // Variável global bool no gamemanager que fica true quando o berserk mode é ativado e
            // quando é true a explosão não consegue causar dano  
        }

    }


    IEnumerator BerserkMode()
    {
        Lasers.SetActive(true);
        shield.SetActive(true);
        attackMode = false;
        GameManager.bossShield = true;
        yield return new WaitForSeconds(30);
        Lasers.SetActive(false);
        shield.SetActive(false);
        attackMode = true;
    }

}

















