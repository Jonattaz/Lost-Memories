using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    // Faz referência ao objeto da global light
    public GameObject globalLight;

    public GameObject playerLight;

    // Controla se o jogador entrou em contato com o console de luz
    private bool lightControl;

    // Controla a música
    bool musicControl;

    [SerializeField]
    // Musica que toca quando o ambiente fica claro
    private AudioClip lightSoundtrack;

  
    // Update is called once per frame
    void Update()
    {
        if (globalLight.activeInHierarchy == false)
        {
            musicControl = true;
        }
        else
        {
            musicControl = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && lightControl)
        {
            if (musicControl)
            {
               AudioManager.Instance.PlayMusicWithFade(lightSoundtrack, 0.3f);
            }
          globalLight.SetActive(true);
            playerLight.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.X)) 
            lightControl = false;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           lightControl = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lightControl = false;
        }
    }


}




