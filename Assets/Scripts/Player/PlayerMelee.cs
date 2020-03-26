using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private Player player;
    private Rigidbody myRigidbody;
    private bool playerStopped = false;
    private bool meleeStarted = false;
    void Start()
    {
        player = GetComponent<Player>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player.state != Player.PlayerStates.melee)
        {
            return;
        }        

        if (!meleeStarted)
        {
            StartCoroutine(MeleeDelay());
            meleeStarted = true;
        }
    }

    //TODO:
    //replace this with melee animation and raycast or melee collider
    private IEnumerator MeleeDelay()
    {
        Debug.Log("Melee attacking.");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Melee finished.");
        player.state = Player.PlayerStates.idle;
        meleeStarted = false;
        playerStopped = false;
    }

    private void FixedUpdate()
    {
        if (player.state == Player.PlayerStates.melee && !playerStopped)
        {
            myRigidbody.velocity = Vector3.zero;
        }
    }
}
