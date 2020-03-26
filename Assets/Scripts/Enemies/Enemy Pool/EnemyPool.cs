using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public Enemy enemyPrefab;
    private Queue<Enemy> enemyPool = new Queue<Enemy>();
    private EnemyLookup enemyLookup;
    private bool poolStarted = false;
    private int initialPoolSize = 5;
    private int incrementalPoolSize = 10;

    void Start()
    {
        enemyLookup = GetComponent<EnemyLookup>();
        FillPool();    
    }

    private void FillPool()
    {
        int fillSize = incrementalPoolSize;
        if (!poolStarted)
        {
            poolStarted = true;
            fillSize = initialPoolSize;
        }

        for (int i = 0; i < fillSize; i++)
        {
            Enemy newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.parent = transform;
            enemyLookup.AddToLookup(newEnemy);
            newEnemy.gameObject.SetActive(false);
            enemyPool.Enqueue(newEnemy);
        }
    }

    public Enemy GetFromPool()
    {
        if (enemyPool.Count == 0)
        {
            FillPool();
        }

        return enemyPool.Dequeue();
    }
}
