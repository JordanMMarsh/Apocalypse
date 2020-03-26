using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerStates
    {
        inactive,
        idle,
        moving,
        rolling,
        melee,
        stunned
    };
    public PlayerStates state = PlayerStates.idle;

}
