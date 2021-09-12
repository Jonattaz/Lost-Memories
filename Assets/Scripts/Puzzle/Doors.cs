using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // Script player
    private Player playerScript;

    // GameObject player
    private GameObject player;

    // Sprite Renderer do objeto
    protected SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider && playerScript.key)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            spriteRend.color = Color.green;
        }
    }

}
