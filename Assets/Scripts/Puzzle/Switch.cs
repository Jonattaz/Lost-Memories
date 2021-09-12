using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Game Object que representa o objeto que é ativado ao atirar no switch
    public GameObject platforms;

    // Sprite Renderer do objeto
    protected SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            spriteRend.color = Color.green;
            platforms.SetActive(true);
        }
    }

}
