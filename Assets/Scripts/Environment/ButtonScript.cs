using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //referencia para armazenar o game object do laser
    public GameObject laser;

    //variavel para detectar quando a intera��o com o bot�o est� disponivel
    bool interacao;

    [SerializeField]
    // Musica que toca quando o ambiente fica claro
    private AudioClip button;

    int control;

    private void Start()
    {
        control = 0;
    }

    private void Update()
    {

        //Se a intera��o com o bot�o estiver disponivel e o jogador apertar X, � chamada a fun��o pra desligar o laser
        if (Input.GetKeyDown(KeyCode.X) && interacao)
        {
            if(control == 0)
            {
                AudioManager.Instance.PlaySFX(button);
                control++;
            }
            DisableLaser();
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        // quando a tag Player entra no trigger do bot�o a interacao fica disponivel
        if (collider.gameObject.CompareTag("Player")) interacao = true;


    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // quando a tag Player entra no trigger do bot�o a interacao fica indispon�vel
        if (collider.gameObject.CompareTag("Player")) interacao = false;
    }

    public void DisableLaser()
    {
        //destroi o game object do laser
        Destroy(laser);
        
    }

}
