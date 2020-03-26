using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float startingHealth = 100f;
    private float currentHealth;
    private CapsuleCollider collider;
    void Start()
    {
        currentHealth = startingHealth;
        collider = GetComponent<CapsuleCollider>();
    }

    public bool DealDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(name + " taking " + damage + " damage.");
        if (currentHealth <= 0)
        {
            Debug.Log(name + " has died.");
            collider.enabled = false;
            return true;
        }
        return false;
    }
}
