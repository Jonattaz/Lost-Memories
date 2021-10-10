using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    // Faz referência ao objeto da global light
    public GameObject globalLight;

    // Controla se o jogador entrou em contato com o console de luz
    private bool lightControl;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && lightControl)
        {
            globalLight.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lightControl = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LightConsole"))
        {
            lightControl = false;

        }

    }

}




