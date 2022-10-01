using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        if(_particleSystem == null)
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if(!_particleSystem.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
