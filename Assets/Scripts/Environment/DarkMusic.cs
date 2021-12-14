using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMusic : MonoBehaviour
{
    [SerializeField]
    // Musica que toca quando o ambiente fica claro
    private AudioClip darkSoundtrack;

    public GameObject playerLight;

    [SerializeField]
    // Bool de permissão
    bool perm;

    // Start is called before the first frame update
    void Start()
    {   if(perm)
        AudioManager.Instance.PlayMusicWithFade(darkSoundtrack, 0.1f);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!playerLight.activeInHierarchy)
            {
                playerLight.SetActive(true);
            }
            AudioManager.Instance.PlayMusicWithFade(darkSoundtrack, 0.1f);
            Destroy(gameObject);
        }

    }


}
