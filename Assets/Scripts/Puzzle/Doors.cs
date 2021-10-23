using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // Script player
    private Player playerScript;

    // GameObject player
    private GameObject player;

    // Bool que controla se a porta leva para outro level ou não
    public bool levelLoad;

    // int que controla qual level será carregado
    public int nextLevel;

    // Sprite Renderer do objeto
    protected SpriteRenderer spriteRend;

    // Representa o gameManager
    GameManager gameManager;


    // GameObject que representa para onde a porta leva o jogador
    public GameObject[] doors;

    //int que represta em qual porta o jogador irá aparecer 
    public int doorID;

    // bool
    private bool active = false;
    private bool sound = false;

    //ARRUMAR O FATO QUE AS VEZES O BOTÃO NÃO FUNCIONA


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        spriteRend = GetComponent<SpriteRenderer>();
        gameManager = GameManager.gameManager;
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
      {
        if (collision.collider && playerScript.key && !levelLoad)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            spriteRend.color = Color.green;
        }else if (collision.collider && levelLoad) 
        {
            gameManager.LoadScene(nextLevel); 
        
        }

        
      }   


    // Controla o teleporte
    IEnumerator Teleport()
    {

        yield return new WaitForSeconds(0.5f);
        player.transform.position = new Vector2(doors[doorID].transform.position.x,
            doors[doorID].transform.position.y);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && active) StartCoroutine(Teleport());

    }


}
