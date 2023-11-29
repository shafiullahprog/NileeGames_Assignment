using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] enemies;

    [SerializeField]float timeToSpawn;

    private void Start()
    {
        StartCoroutine(spawnEnemyUsingPool());
        //StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(timeToSpawn);
        var specificEnemy = enemies[Random.Range(0, enemies.Length)];
        var specificPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = Instantiate(specificEnemy, specificPoint.transform);
        yield return new WaitForSeconds(timeToSpawn);
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemyUsingPool()
    {
        yield return new WaitForSeconds(timeToSpawn);
       
            var specificEnemy = enemies[Random.Range(0, enemies.Length)];

            GameObject g = ObjectPool.instance.GetPooledObject(specificEnemy);
            var specificPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            g.SetActive(true);
            g.transform.position = specificPoint.transform.position;
        
        yield return new WaitForSeconds(timeToSpawn);
        StartCoroutine(spawnEnemyUsingPool());
    }
}
