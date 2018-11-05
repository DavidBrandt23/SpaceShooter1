using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerControl : MonoBehaviour {
    private Player player;
    private bool shootPressed;

    private void Awake()
    {
        player = GetComponent<Player>();
    }


    private void Update()
    {
      
            shootPressed = Input.GetButton("Shoot");
        
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        int xDirection = (int)Input.GetAxis("Horizontal");
        int yDirection = (int)Input.GetAxis("Vertical");
        // Pass all parameters to the character control script.
        //player.Move(0,0, shootPressed);
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //player.SetPosition(pos);
        player.Move(xDirection, yDirection, shootPressed);
    }
}
