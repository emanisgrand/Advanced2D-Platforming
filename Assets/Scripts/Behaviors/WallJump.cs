using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : AbstractBehavior
{
    public Vector2 jumpVelocity = new Vector2(50, 200);

    // Update is called once per frame
    void Update()
    {
        if (collisionState.onWall && !collisionState.standing){
            var canJump = inputState.GetButtonValue(inputButtons[0]);
            if (canJump){
                // the animation is set to look left so we're going to flip the direction its facing.
                inputState.direction = inputState.direction == Directions.Right ? Directions.Left : Directions.Right;
                // this will handle the actual movement.
                body2D.velocity = new Vector2(jumpVelocity.x * (float)inputState.direction, jumpVelocity.y);
            }
        }    
    }
}
