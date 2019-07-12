using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : StickToWall
{
    public float slideVelocity = -5f;
    // we want to increase the value of the slide velocity
    // so we create a multiplier to do that.
    public float slideMultiplier = 5f;
    public GameObject dustPrefab;
    public float dustSpawnDelay = 1.5f;    
    

    private float timeElapsed = 0;

    override protected void Update() {
        base.Update();

        if(onWallDetected && !collisionState.standing) {
            var velY = slideVelocity;

            if (inputState.GetButtonValue(inputButtons[0]))
                velY *= slideMultiplier;  // multiply the slide velocity. So -5*5=-25 which will speed it up.

            body2D.velocity = new Vector2(body2D.velocity.x, velY);

            if(timeElapsed > dustSpawnDelay){
                var dust = Instantiate(dustPrefab);
                var pos = transform.position;
                pos.y += 2;
                dust.transform.position = pos;
                dust.transform.localScale = transform.localScale;
                timeElapsed = 0;
            }
            timeElapsed += Time.deltaTime;
        }
    }
    //disable gravity manipulation logic that we used to stick
    // to the wall in StickToWall. We're not really using that here.
    // our goal instead is to slide. Not stick. :)
    override protected void OnStick(){
        body2D.velocity = Vector2.zero; // this should help us slow the player down

    }
    override protected void OffWall(){
        // reset the timer.
        timeElapsed = 0;
    }
}
