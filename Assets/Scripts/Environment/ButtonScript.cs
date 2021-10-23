using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //referencia para armazenar o game object do laser
    public GameObject laser;

    //variavel para detectar quando a interação com o botão está disponivel
    bool interacao;


    void OnTriggerEnter2D(Collider2D collider)
    {
        // quando a tag Player entra no trigger do botão a interacao fica disponivel
        if (collider.gameObject.CompareTag("Player")) interacao = true;


        //Se a interação com o botão estiver disponivel e o jogador atirar, é chamada a função pra desligar o laser
        if (interacao && collider.gameObject.CompareTag("Bullet"))
        {
            DisableLaser();
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // quando a tag Player entra no trigger do botão a interacao fica indisponível
        if (collider.gameObject.CompareTag("Player")) interacao = false;
    }

    public void DisableLaser()
    {
        //destroi o game object do laser
        Destroy(laser);
        
    }

}
