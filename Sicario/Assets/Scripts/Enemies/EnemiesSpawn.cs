using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemiesSpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;
    [SerializeField] bool looping = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if(SceneManager.GetActiveScene().name != "StartMenu" && SceneManager.GetActiveScene().name != "WinGame")
        yield return new WaitForSeconds(3f);
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }
    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {

            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfigs[waveIndex]));
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.getEnemyPrefab(), waveConfig.getPath()[0].position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawns());
        }
    }
    public void setLooping(bool isLoop)
    {
        this.looping = isLoop;
    }
}
