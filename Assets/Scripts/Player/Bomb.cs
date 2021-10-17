using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Variável que representa o game Object que será a explosão
    public GameObject explosion;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Colocar um corrotina para explodir a bomba depois de um determinado tempo, talvez
        // Destroi a bomba
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

      
    }


}
