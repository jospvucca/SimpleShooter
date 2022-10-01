using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject _hazard;
    public int _hazardCont;
    public float _startWait;
    public float _spawnWait;
    public float _waveWait;
    public Text _scoreText;
    public int _score;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        UpdateScoreText();
        StartCoroutine(SpawnWaves());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(_startWait);
        while (true)
        {
            for (int i = 0; i < _hazardCont; i++)
            {
                Vector3 _spawnPosition = new Vector3(Random.Range(-6.0f, 6.0f), 0.0f, 16.0f);
                Instantiate(_hazard, _spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(_spawnWait);
            }
            yield return new WaitForSeconds(_waveWait);
        }
    }

    public void ChangeScore(int scoreValue)
    {
        _score += scoreValue;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
