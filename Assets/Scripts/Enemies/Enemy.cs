using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyStates
    {
        inactive,
        idle,
        stunned
    };
    public EnemyStates state = EnemyStates.idle;

    public EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }
}
