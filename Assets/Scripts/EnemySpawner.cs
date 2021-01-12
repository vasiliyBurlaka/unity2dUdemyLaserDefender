using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        WaveConfig currentWave = waveConfigs[startWave];
        StartCoroutine(SpawnAllEnemies(currentWave));
    }

    IEnumerator SpawnAllEnemies(WaveConfig waveConfig)
    {
        Debug.Log("SpawnAllEnemies");
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            Debug.Log("SpawnAllEnemies LOOP " + i.ToString());
            Instantiate(
                waveConfig.GetEnemyPrefab(), 
                waveConfig.GetWaypoints()[0].transform.position, 
                Quaternion.identity
            );

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
