using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : StickToWall
{
    public float slideVelocity = -5;

    override protected void Update() {
        base.Update();

        if(onWallDetected) {
            var velY = slideVelocity;

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
