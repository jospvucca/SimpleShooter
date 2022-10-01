using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [System.Serializable]
    public class Boundaries
    {
        public float _xMin, _xMax, _zMin, _zMax;
    }

    public Boundaries _boundary;
    public Rigidbody _playerRigidBody;
    public GameObject _shot;
    public float _shotRate;
    public float _speed;
    public float _tilt;
    float _nextShot;

    // Start is called before the first frame update
    void Start()
    {
        if(_playerRigidBody == null)
        {
            Debug.Log("RigidBody not selected.");
            _playerRigidBody = gameObject.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextShot) 
        {
            _nextShot = Time.time + _shotRate;
            Instantiate(_shot, transform.position + new Vector3(0.0f, 0.0f, 1.25f), Quaternion.identity);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _playerRigidBody.velocity = new Vector3(x, 0.0f, z) * _speed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _boundary._xMin, _boundary._xMax), 0.0f, Mathf.Clamp(transform.position.z, _boundary._zMin, _boundary._zMax));
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, _playerRigidBody.velocity.x * -_tilt);
    }
}
