using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMusic : MonoBehaviour
{
    [SerializeField]
    // Musica que toca quando o ambiente fica claro
    private AudioClip darkSoundtrack;

    [SerializeField]
    // Bool de permissão
    bool perm;

    // Start is called before the first frame update
    void Start()
    {   if(perm)
        AudioManager.Instance.PlayMusicWithCrossFade(darkSoundtrack, 0.1f);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayMusicWithCrossFade(darkSoundtrack, 0.1f);
            Destroy(gameObject);
        }

    }


}
