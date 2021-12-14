using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : Enemy
{
    [SerializeField]
    private AudioClip music;

    private void Start()
    {
        if (music != null)
        {
            AudioManager.Instance.PlayMusic(music);
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
  
        if (!GameManager.cameraOff)
        {
            if (Mathf.Abs(targetDistance) < attackDistance)
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

}
