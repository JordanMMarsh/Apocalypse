using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyPool enemyPool;

    void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();
        StartCoroutine(SpawnTestEnemy());
    }

    private void SpawnEnemies(Vector3 spawnPosition, int numEnemies = 1)
    {
       for (int i = 0; i < numEnemies; i++)
       {
            Enemy newEnemy = enemyPool.GetFromPool();
            newEnemy.transform.position = spawnPosition;
            newEnemy.transform.rotation = transform.rotation;
            newEnemy.gameObject.SetActive(true);
       }
    }

    //Wait for enemy pool to fill, then spawn one test enemy.
    private IEnumerator SpawnTestEnemy()
    {
        yield return new WaitForSeconds(2f);
        SpawnEnemies(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
    }
}
