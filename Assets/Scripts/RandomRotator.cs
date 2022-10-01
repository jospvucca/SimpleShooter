using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float _tumble;
    public Rigidbody _asteroidRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        if(_asteroidRigidBody == null)
        {
            Debug.Log("Error.");
            _asteroidRigidBody = GetComponent<Rigidbody>();
        }
        _asteroidRigidBody.angularVelocity = Random.insideUnitSphere * _tumble;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
