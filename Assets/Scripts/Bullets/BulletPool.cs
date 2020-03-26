using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public Bullet bulletPrefab;
    //Does this enemy lookup belong here?
    private EnemyLookup enemyLookup;
    private int initialPoolSize = 20;
    private int incrementPoolSize = 10;
    private bool poolStarted = false;

    private Queue<Bullet> bulletPool = new Queue<Bullet>();
    private void Start()
    {
        enemyLookup = FindObjectOfType<EnemyLookup>();
        FillPool();
    }

    private void FillPool()
    {
        int poolSize;
        if (!poolStarted)
        {
            poolSize = initialPoolSize;
        }
        else
        {
            poolSize = incrementPoolSize;
        }

        for (int i = 0; i < poolSize; i++)
        {
            Bullet newBullet = Instantiate(bulletPrefab);
            newBullet.transform.parent = transform;
            newBullet.SetEnemyLookup(enemyLookup);
            newBullet.gameObject.SetActive(false);
            bulletPool.Enqueue(newBullet);
        }
    }

    public Bullet GetBullet()
    {
        if (bulletPool.Count == 0)
        {
            FillPool();
        }

        return bulletPool.Dequeue();
    }

    public void AddToPool(Bullet bulletToAdd)
    {
        bulletToAdd.gameObject.SetActive(false);
        bulletToAdd.transform.position = transform.position;
        bulletPool.Enqueue(bulletToAdd);
    }
}
