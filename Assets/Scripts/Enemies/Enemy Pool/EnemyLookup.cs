using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookup : MonoBehaviour
{
    Dictionary<string, Enemy> enemyLookup = new Dictionary<string, Enemy>();
    private int enemyIndex = 0;
    private string enemyNaming = "Enemy";

    //Called from EnemyPool.cs each time a new enemy is instantiated. 
    //This changes the name to a unique key and adds the enemy to the dictionary for quick lookup when needed
    public void AddToLookup(Enemy enemyToAdd)
    {
        string key = enemyNaming + enemyIndex;
        enemyToAdd.name = key;
        enemyLookup.Add(key, enemyToAdd);
        enemyIndex++;
    }
    public Enemy LookupEnemy(string name)
    {
        Enemy enemy;
        enemyLookup.TryGetValue(name, out enemy);
        if (enemy != null)
        {
            Debug.Log("Enemy found.");
            return enemy;
        }
        else
        {
            Debug.Log("Enemy not found.");
            return null;
        }
    }
}
