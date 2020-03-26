using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletPool bulletPool;
    private EnemyLookup enemyLookup;
    private Rigidbody myRigidbody;
    private float bulletSpeed = 10f;
    public float bulletDamage = 30f;
    public bool isActive = false;

    private void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void SetEnemyLookup(EnemyLookup lookup)
    {
        enemyLookup = lookup;
    }

    public void SetAsActive()
    {
        isActive = true;
        StartCoroutine(BulletTimeOut());
    }

    private void FixedUpdate()
    {
        if (!isActive)
        {
            return;
        }

        //Bullet movement
        myRigidbody.MovePosition(transform.position + transform.forward * bulletSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
        {
            return;
        }

        if (other.tag == "Enemy")
        {
            if (enemyLookup == null)
            {
                Debug.LogWarning("Enemy lookup not set.");
            }
            else
            {
                enemyLookup.LookupEnemy(other.name).enemyHealth.DealDamage(bulletDamage);
            }
            isActive = false;
            bulletPool.AddToPool(this);
        }
    }

    //Timer used so bullet doesn't fly forever.
    private IEnumerator BulletTimeOut()
    {
        yield return new WaitForSeconds(5f);
        isActive = false;
        bulletPool.AddToPool(this);
    }
}
