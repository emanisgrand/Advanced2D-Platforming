using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongJump : Jump
{
    public float longJumpDelay      = 0.15f;
    public float longJumpMultiplier = 1.5f;
    public bool canLongJump;
    public bool isLongJumping;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    override protected void Update() {
        // copied from Jump.cs
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);
        
        if (!canJump)
            canLongJump = false; // can't long jump if you can't jump

        if (collisionState.standing && isLongJumping)
            isLongJumping = false;    

        base.Update();  // calls all other logic created in Jump.cs

        if (canLongJump && !collisionState.standing && holdTime > longJumpDelay){
            var vel = body2D.velocity;
            body2D.velocity = new Vector2 (vel.x, jumpSpeed * longJumpMultiplier);
            canLongJump = false;
            isLongJumping = true;
        }
    }

    protected override void OnJump(){
        base.OnJump();
        canLongJump = true;      // resets canLongJump 
    }

}
