﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehavior
{
    public float jumpSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);
        
        if (collisionState.standing) {
            if (canJump && holdTime < .1f){      // the reason we don't test for 0 is-a small amount of time takes place 
                OnJump();                         //from when the button is detected and changed on the input state, 
                print(inputState.GetButtonHoldTime(0));                  //to when the jump script actually executes.
            }                                    
        }
    }
    protected virtual void OnJump(){
        var vel = body2D.velocity;
        // body.velocity = (x=velx, y=jumpSpeed)
        body2D.velocity = new Vector2(vel.x, jumpSpeed);
    }
}
// going to make a branch to track limiting the jump behavior
// now we're actually working in a new branch; jumptracker