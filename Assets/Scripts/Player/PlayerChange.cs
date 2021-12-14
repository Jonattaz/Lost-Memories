using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    [SerializeField]
    // Jogador com arma
    private GameObject playerComArma;

    [SerializeField]
    // Jogador sem arma
    private GameObject playerSemArma;

    [SerializeField]
    // Camera que segue o jogador sem arma
    private GameObject camJogadorSemArma;

    [SerializeField]
    // Camera que segue o jogador com arma
    private GameObject camJogadorArma;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.unlockGun)
        {
            playerComArma.SetActive(true);
            camJogadorArma.SetActive(true);
            Destroy(playerSemArma);
            Destroy(camJogadorSemArma);
        }    
    }
}
