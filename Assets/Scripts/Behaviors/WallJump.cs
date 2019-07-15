using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 I thought we already had a jump!
 We do. This script was created to alllow players to jump off of the wall
 once they are stuck on it.
 */

public class WallJump : AbstractBehavior
{
    public bool     jumpingOffWall;
    public Vector2  jumpVelocity    = new Vector2(50, 200);
    public float    resetDelay      =.2f;
    
    private float   timeElapsed     = 0;

    // Update is called once per frame
    void Update()
    {
        if (collisionState.onWall && !collisionState.standing){
            var canJump = inputState.GetButtonValue(inputButtons[0]);
            if (canJump && !jumpingOffWall) {

                // the animation is set to look left so we're going to flip the direction its facing.
                inputState.direction = inputState.direction == Directions.Right ? Directions.Left : Directions.Right;
                // this will handle the actual movement. TODO: //*adjust jump so its not so jerky /
                body2D.velocity = new Vector2(jumpVelocity.x * (float)inputState.direction, jumpVelocity.y);
            
                ToggleScripts(false);
                jumpingOffWall = true;
            }
        }    

        if (jumpingOffWall) {   // if we're jumping off the wall (so if the the body2d is on the move)
            timeElapsed += Time.deltaTime; // start the timer
            if(timeElapsed > resetDelay){ // check if the timer's gone past the reset delay
                ToggleScripts(true);  // disable any scripts specified by the togglescripts function
                jumpingOffWall = false; // we're not jumping off the wall anymore
                timeElapsed = 0;  // *! reset the timer. Eventually you'll be hitting the ground and none of this will be relevant anymore.
            }
        }

    }
}
