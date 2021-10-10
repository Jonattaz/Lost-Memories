using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : Enemy
{
    
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Mathf.Abs(targetDistance) < attackDistance)
        {
            attack = true;
        }
    }

}
