using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Player player;
    private PlayerRolling playerRolling;
    private Rigidbody myRigidbody;
    private Vector3 vertMovement;
    private Vector3 horzMovement;
    private float movementSpeed = 5f;
    void Start()
    {
        player = GetComponent<Player>();
        playerRolling = GetComponent<PlayerRolling>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float vertInput = Input.GetAxis("Vertical");
        float horzInput = Input.GetAxis("Horizontal");

        #region State Checks
        if (player.state != Player.PlayerStates.moving)
        {
            return;
        }

        if (vertInput == 0 && horzInput == 0)
        {
            player.state = Player.PlayerStates.idle;
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && playerRolling.availableRolls > 0)
        {
            player.state = Player.PlayerStates.rolling;
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            player.state = Player.PlayerStates.melee;
            return;
        }
        #endregion

        vertMovement = vertInput * movementSpeed * Vector3.forward;
        horzMovement = horzInput * movementSpeed * Vector3.right;
    }

    private void FixedUpdate()
    {
        if (player.state != Player.PlayerStates.moving)
        {
            return;
        }

        myRigidbody.velocity = vertMovement;
        myRigidbody.velocity += horzMovement;
    }
}
