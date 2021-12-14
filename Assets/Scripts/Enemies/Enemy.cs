using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Variável que representa a vida
    public int health;

    // Variável que representa a velocidade
    public float speed;

    // Váriavel que controla se o inimigo irá atacar ou não
    public bool attack;

    // Variável que representa a distância dos ataques
    public float attackDistance;

    // Objeto que será instânciado quando este objeto ser destruido
    public GameObject coin;

    // Objeto que representa o sprite que aparece quando este objeto for destruido
    //public GameObject deathAnimation;

    // Animator
    protected Animator anim;

    // Verifica para qual lado o objeto está virado
    protected bool facingRight = true;

    // Objeto que representa o alvo que será perseguido
    protected Transform target;

    // Variável que representa a distância entre este objeto e o alvo
    protected float targetDistance;

    // Rigidbody do objeto
    protected Rigidbody2D rb;

    // Sprite Renderer do objeto
    protected SpriteRenderer spriteRend;
    [SerializeField]
    private AudioClip damageSound;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        target = FindObjectOfType<Player>().transform;
        targetDistance = transform.position.x - target.position.x;
    }


    // Método responsável pela ação de virar o sprite do objeto de acordo com o lado que ele for
    protected void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Método para quando este objeto receber um dano do jogador
    public void TookDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            AudioManager.Instance.PlaySFX(damageSound);
            Instantiate(coin, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(TookDamage());
        }

    }


    // Corrotina responsável pelo parte estética do dano que este objeto irá levar
    IEnumerator TookDamage()
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = Color.white; 
    }


}



















