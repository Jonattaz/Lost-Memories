using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Representa a quantidade de bombas
    public int bombs;    
   
    // Representa a quantidade de vida
    public int health;

    [SerializeField]
    // Musica que toca quando o ambiente fica claro
    private AudioClip coletavel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            AudioManager.Instance.PlaySFX(coletavel);
            player.SetHealthAndBombs(health, bombs);
            Destroy(gameObject);
        }


    }


}
