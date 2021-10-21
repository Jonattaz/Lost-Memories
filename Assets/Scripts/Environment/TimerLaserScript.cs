using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script para o laser que fica ativado e desativado por um tempo
public class TimerLaserScript : MonoBehaviour
{
   
    //referencia para a linha do laser
    public LineRenderer TimerlineRenderer;

    //ponto inicial da linha
    public Transform TimerLaserStart;

    //ponto final da linha
    public Transform TimerLaserFinal;

    // collider da linha
    public BoxCollider2D timerLaserCollider;


    // contador

    // Variavel para a quantidade de tempo que o laser ficar� ligado
    public float startTime;
    
    // variavel para a quantidade de tempo que o laser ficar� desligado
    public float startChargeTime;

    //Variavel para o tempo passado desde o startTime
    public float currentTime;

    //variavel para guardar o tempo passado desde o startChargeTime
    float chargeTime;

    void Start()
    {
        //igualando os contadores com os tempos iniciais para depois iniciar a contagem
        currentTime = startTime;
        chargeTime = startChargeTime;

        timerLaserCollider = GetComponent<BoxCollider2D>();

        //fun��o para ligar o laser
       EnableTimerLaser();
    }


    void Update()
    {
            timerLaserCollider.enabled = true;
            //iniciando a contagem de quanto tempo o laser ficar� ligado
            currentTime -= 1 * Time.deltaTime;


            if (currentTime <= 0)
            {
                //com a contagem chegando a 0 o laser � desabilitado por essa fun��o
                DisableTimerLaser();

                //come�a a contagem do tempo em que ele ficar� desligado
                chargeTime -= 1 * Time.deltaTime;

                if (chargeTime <= 0)
                {
                    //com a contagem chegando a 0 o laser � ligado novamente pela fun��o
                    EnableTimerLaser();

                    //os contadores s�o resetados para come�ar o processo novamente
                    currentTime = startTime;
                    chargeTime = startChargeTime;
                }
            }   
    }

    public void EnableTimerLaser()
    {
        //ativar a linha do laser
        TimerlineRenderer.enabled = true;

        //ativar o collider do laser
        timerLaserCollider.enabled = true;

        //setar o ponto inicial da linha na posi��o do transform TimerLaserStart
        TimerlineRenderer.SetPosition(0, TimerLaserStart.transform.position);

        //setar o ponto final da linha na posi��o do tranform TimerLaserFinal
        TimerlineRenderer.SetPosition(1, TimerLaserFinal.transform.position);

    }

    public void DisableTimerLaser()
    {
        //desativar a linha do laser
        TimerlineRenderer.enabled = false;

        //desativar o collider do laser
        timerLaserCollider.enabled = false;
    }
}
