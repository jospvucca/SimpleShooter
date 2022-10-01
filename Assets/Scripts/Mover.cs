using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float _speed;
    public Rigidbody _projectileRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        if(_projectileRigidBody == null)
        {
            Debug.Log("Missing Reference.");
            _projectileRigidBody = GetComponent<Rigidbody>();
        }
        _projectileRigidBody.velocity = transform.forward * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -10 || transform.position.z > 20)
        {
            Destroy(this.gameObject);
        }
    }
}
