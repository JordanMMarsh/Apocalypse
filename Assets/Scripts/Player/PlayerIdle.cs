using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : MonoBehaviour
{
    private Player player;
    private PlayerRolling playerRolling;
    void Start()
    {
        player = GetComponent<Player>();
        playerRolling = GetComponent<PlayerRolling>();
    }

    void Update()
    {
        #region State Checks
        if (player.state != Player.PlayerStates.idle)
        {
            return;
        }

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            player.state = Player.PlayerStates.moving;
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
    }
}
