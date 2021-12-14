using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    // Referência boss
    private GameObject boss;

    [SerializeField]
    // Referência laser
    private GameObject laser;

    // Update is called once per frame
    void Update()
    {
        if (boss == null || !boss.activeInHierarchy) 
        {
            Destroy(laser);

        }
    }
}
