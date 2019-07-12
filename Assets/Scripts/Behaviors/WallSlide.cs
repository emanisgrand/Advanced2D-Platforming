using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : StickToWall
{
    public float slideVelocity = -5f;
    // we want to increase the value of the slide velocity
    // so we create a multiplier to do that.
    public float slideMultiplier = 5f;
    

    override protected void Update() {
        base.Update();

        if(onWallDetected) {
            var velY = slideVelocity;

            // TODO: we always use the first input in the array. I'm not sure why
            // I believe it's because we set the input in the inspector. In this case: down
            if (inputState.GetButtonValue(inputButtons[0]))
                velY *= slideMultiplier;  // multiply the slide velocity. So -5*5=-25 which will speed it up.

            body2D.velocity = new Vector2(body2D.velocity.x, velY);
        }
    }
    //disable gravity manipulation logic that we used to stick
    // to the wall in StickToWall. We're not really using that here.
    // our goal instead is to slide. Not stick. :)
    override protected void OnStick(){
        body2D.velocity = Vector2.zero; // this should help us slow the player down

    }
    override protected void OffWall(){
        // this doesn't really do anything. this is just to continue disabling the logic deriving from 
        // stick to wall
    }
}
