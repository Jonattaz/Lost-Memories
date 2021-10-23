using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Sprite Renderer do objeto
    protected SpriteRenderer spriteRend;

    [SerializeField]
    // Representa a velocidade da plataforma
    float moveSpeed = 3f;

    // Controla quando a plataforma deve subir o desçer
    bool moveUp = true;

    // Para onde o elevador irá. Ponto final
    public Transform destination;

    // Ponto de inicio da plataforma
    public Transform startPoint;

    // Plataforma
    public GameObject platform;

    [SerializeField]
    // Controla se a plataforma está ligada ou não
    bool platformOn;

    // Bools de controle
    private bool active;
    private bool sound;   

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (platformOn)
        {
            Move();
        }

        // Quando o jogador para de apertar a tecla o teleporte para
        if (Input.GetKeyUp(KeyCode.X))
        {
            active = false;
            if (sound)
            {
                //SoundManager.PlaySound("Teleport");
                sound = false;
            }

        }

        // Quando o botão é apertado o teleporte funciona
        if (Input.GetKeyDown(KeyCode.X))
        {
            active = true;

        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && active)
        {
            spriteRend.color = Color.green;
            platformOn = true;
        }
    }
        
    

    // Controls the elevator movement
    void Move()
    {
        if (platform.transform.position.y >= destination.position.y)
        {
            moveUp = false;
        }
        if (platform.transform.position.y <= startPoint.position.y)
        {
            moveUp = true;
        }

        if (moveUp)
        {
            platform.transform.position = new Vector2(platform.transform.position.x, 
                platform.transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            platform.transform.position = new Vector2(platform.transform.position.x,
                platform.transform.position.y - moveSpeed * Time.deltaTime);
        }

    }


}
