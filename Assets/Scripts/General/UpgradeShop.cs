using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UpgradeShop : MonoBehaviour
{
    // Referência todos os textos do painel de upgrade
    public Text upgradeCostText;

    // Referência ao GameManager
    GameManager gameManager;

    // Referência ao Player
    Player player;

    public Button granadeButton;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameManager.gameManager;
        player = FindObjectOfType<Player>();
        UpdateUI();

    }

    // Método que atualiza os valores na tela de upgrade
    private void UpdateUI()
    {
        upgradeCostText.text = "Upgrade Cost: " + gameManager.upgradeCost;
    }

    // Método para o botão de upgrade da vida(health)
    public void SetHealth()
    {
        if (gameManager.coins >=  gameManager.upgradeCost)
        {
            gameManager.health += 10;
            FindObjectOfType<UIManager>().UpdateHealthBar();
            player.SetPlayerStatus();
            SetCoins(gameManager.upgradeCost);
            UpdateUI();

        }
    }
    
    
    // Método para o botão de upgrade do número de munição
    public void SetBullets()
    {
        if ( gameManager.coins  >=  gameManager.upgradeCost)
        {
            gameManager.bullets += 10;

            player.SetPlayerStatus();
            SetCoins(gameManager.upgradeCost);
            UpdateUI();
        }
    }
    
    // Desativa as câmeras
    public void SetSecurityCam()
    {
        if (gameManager.coins >= gameManager.upgradeCost)
        {
            StartCoroutine(SecurityCam());
            SetCoins(gameManager.upgradeCost);
        }

    }

    // Ativa a granada
    public void SetGranade()
    {
        if (gameManager.coins >= gameManager.upgradeCost && !GameManager.granadeOn)
        {
            if (!GameManager.granadeOn)
            {
                gameManager.bombs += 1;
                GameManager.granadeOn = true;
                granadeButton.interactable = false;
                player.SetPlayerStatus();
                SetCoins(gameManager.upgradeCost);
                UpdateUI();
            }
           
        }

    }

    IEnumerator SecurityCam()
    {
        GameManager.cameraOff = true;
        yield return new WaitForSeconds(30);
        GameManager.cameraOff = false;
    }


    // Método que atualiza o número de moedas que o player possui após realizar o upgrade
    private void SetCoins(int coin)
    {
        gameManager.coins -= coin;
        FindObjectOfType<UIManager>().UpdateCoinsUI();
    }

}























