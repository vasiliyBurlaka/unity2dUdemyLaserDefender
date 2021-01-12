﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while(looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++) {
            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfigs[waveIndex]));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            GameObject newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(), 
                waveConfig.GetWaypoints()[0].transform.position, 
                Quaternion.identity
            );
            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
