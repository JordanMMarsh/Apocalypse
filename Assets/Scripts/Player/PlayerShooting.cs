using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Player player;
    private PlayerWeapon playerWeapon;
    private BulletPool bulletPool;
    private bool canShoot = true;
    public Transform gun;

    void Start()
    {
        player = GetComponent<Player>();
        playerWeapon = GetComponent<PlayerWeapon>();
        bulletPool = FindObjectOfType<BulletPool>();
    }

    void Update()
    {
        if (player.state != Player.PlayerStates.idle && player.state != Player.PlayerStates.moving)
        {
            return;
        }        

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canShoot)
            {
                Bullet newBullet = bulletPool.GetBullet();
                newBullet.transform.position = gun.transform.position;
                newBullet.transform.rotation = gun.transform.rotation;
                newBullet.gameObject.SetActive(true);
                newBullet.SetAsActive();
                canShoot = false;
                StartCoroutine(FireDelay());
            }
        }
    }

    private IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
