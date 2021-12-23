using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleClone : MonoBehaviour
{
    private float particletimer = 0.0f;
    private float particletime = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {      
            particletimer += Time.deltaTime;

            if (particletimer > particletime)
            {
                Destroy(this.gameObject);
            }    
    }
}
