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
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider && playerScript.key && !levelLoad)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            spriteRend.color = Color.green;
        }else if (collision.collider && playerScript.key) 
        {
            gameManager.LoadScene(nextLevel);
        
        }
    }



}
