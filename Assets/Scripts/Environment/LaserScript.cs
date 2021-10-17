using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script do laser que funciona com o botão
public class LaserScript : MonoBehaviour
{
    // referencia para a linha do laser
    public LineRenderer lineRenderer;

    //ponto inicial da linha
    public Transform LaserStart;

    //ponto final da linha
    public Transform LaserFinal;

    //collider da linha
    public BoxCollider2D laserCollider;


    void Start()
    {       
        laserCollider = GetComponent<BoxCollider2D>();

        //função para ativar a linha do laser
        EnableLaser();
    }

    public void EnableLaser()
    {
        //ativar a linha do laser
        lineRenderer.enabled = true;

        //ativar o collider do laser
        laserCollider.enabled = true;

        //setar o ponto inicial da linha na posição do transform LaserStart
        lineRenderer.SetPosition(0, LaserStart.transform.position);

        //setar o ponto final da linha na posição do tranform LaserFinal
        lineRenderer.SetPosition(1, LaserFinal.transform.position);

    }

}
