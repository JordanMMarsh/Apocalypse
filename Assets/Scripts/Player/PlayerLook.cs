using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Player player;
    private Camera cam;
    void Start()
    {
        player = GetComponent<Player>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.state == Player.PlayerStates.inactive || player.state == Player.PlayerStates.stunned)
        {
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(GetRay(), out hit))
        {
            Vector3 lookPoint = hit.point;
            lookPoint.y = transform.position.y;
            transform.LookAt(lookPoint);
        }
    }

    Ray GetRay()
    {
        return cam.ScreenPointToRay(Input.mousePosition);
    }
}
