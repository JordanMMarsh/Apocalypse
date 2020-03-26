using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public enum MeleeWeaponTypes
    {
        unarmed,
        knife,
        axe,
        sword
    };

    public enum FirearmTypes
    {
        pistol,
        smg,
        rifle,
        sniper
    };

    public float meleeWeaponDamage = 10f;
    public float firearmDamage = 30f;
}
