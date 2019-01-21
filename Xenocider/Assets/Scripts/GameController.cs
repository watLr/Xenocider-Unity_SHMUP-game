using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject bossHazard;
    public GameObject[] hazards;
    public Vector3 spawnValues;    
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int BossEnterValue;

    public Text ScoreText;
    public int score;
    private new AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            while (audio.volume >= 0.1f)
            {
                audio.volume -= 0.01f;
            }
        }
        else
        {
            while (audio.volume < 0.5f)
            {
                audio.volume += 0.01f;
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (score < BossEnterValue)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
        yield return new WaitForSeconds(waveWait);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRot = Quaternion.identity;
        Instantiate(bossHazard, spawnPos, spawnRot);
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }
}
