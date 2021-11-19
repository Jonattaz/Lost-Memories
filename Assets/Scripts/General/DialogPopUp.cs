using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopUp : MonoBehaviour
{
    // GameObject do dialogo
    public GameObject dialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialog.SetActive(true);
            GameManager.dialogMode = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialog.SetActive(false);
            GameManager.dialogMode = false;
            GameManager.offense = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.offense = false;
        }
    }

}
