using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //referencia para armazenar o game object do laser
    public GameObject laser;

    //variavel para detectar quando a interação com o botão está disponivel
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

        //Se a interação com o botão estiver disponivel e o jogador apertar X, é chamada a função pra desligar o laser
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
        // quando a tag Player entra no trigger do botão a interacao fica disponivel
        if (collider.gameObject.CompareTag("Player")) interacao = true;


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
