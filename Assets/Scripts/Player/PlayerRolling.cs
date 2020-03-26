using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRolling : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Player player;
    private bool rollStarted = false;
    private bool rechargeCoroutineStarted = false;
    private int maxRolls = 2;
    public int availableRolls;
    public TextMeshProUGUI rollsText;

    void Start()
    {
        player = GetComponent<Player>();
        myRigidbody = GetComponent<Rigidbody>();
        availableRolls = maxRolls;
        UpdateRollsText();
    }

    void FixedUpdate()
    {
        if (player.state != Player.PlayerStates.rolling)
        {
            return;
        }          

        if (!rollStarted)
        {
            rollStarted = true;
            myRigidbody.velocity = transform.forward * 10f;
            availableRolls--;
            UpdateRollsText();
            StartCoroutine(RollTimer());
            if (!rechargeCoroutineStarted)
            {
                StartCoroutine(RechargeRoll());
                rechargeCoroutineStarted = true;
            }
        }
    }

    private IEnumerator RollTimer()
    {
        yield return new WaitForSeconds(0.5f);
        rollStarted = false;
        myRigidbody.velocity = Vector3.zero;
        player.state = Player.PlayerStates.idle;
    }

    private IEnumerator RechargeRoll()
    {
        yield return new WaitForSeconds(5f);
        availableRolls++;
        UpdateRollsText();
        if (availableRolls < maxRolls)
        {
            StartCoroutine(RechargeRoll());
        }
        else
        {
            rechargeCoroutineStarted = false;
        }
    }

    private void UpdateRollsText()
    {
        if (rollsText != null)
        {
            rollsText.text = "Rolls: " + availableRolls;
        }
        else
        {
            Debug.LogError("Rolls text not hooked up.");
        }
    }
}
