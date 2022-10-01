using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject _explosion;
    public GameObject _playerExplosion;
    public int _scoreValue;
    GameObject _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(_playerExplosion, transform.position, Quaternion.identity);
            //Application.Quit();
        }
        else
        {
            _gameManager.GetComponent<GameManager>().ChangeScore(_scoreValue);
            Instantiate(_explosion, transform.position, Quaternion.identity);
        }
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
