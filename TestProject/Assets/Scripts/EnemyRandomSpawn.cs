using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour {

    public GameObject enemy;

    public int EnemyCount;
    public float interval;

    private void Update()
    {
        //Basic spawning: if player inputs "1", then spawns 1 enemy
        // If player inputs "Q", spawns a wave using the SpawnWave function
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Generates random horizontal spawn coordinate, then instantiates enemy at top of screen
            float spawnPoint = Random.Range(-2.5f, 2.5f);
            Instantiate(enemy, new Vector3(spawnPoint, 4.5f, 0), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine (SpawnWave());
        }
    }

    //Function to spawn wave - needs to be coroutine to run alongside game
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
