using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour {

    public GameObject enemy;

    public int EnemyCount;
    public float interval;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            float spawnPoint = Random.Range(-2.5f, 2.5f);
            Instantiate(enemy, new Vector3(spawnPoint, 4.5f, 0), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine (SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            float spawnPoint = Random.Range(-2.5f, 2.5f);
            Instantiate(enemy, new Vector3(spawnPoint, 4.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

}
