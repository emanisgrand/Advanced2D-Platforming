using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToWall : AbstractBehavior {

    public bool onWallDetected;

    protected float defaultGravityScale;
    protected float defaultDrag;

    // Start is called before the first frame update
    void Start() {
        defaultGravityScale = body2D.gravityScale;
        defaultDrag = body2D.drag;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (collisionState.onWall){
            // make sure we're in the correct state because
            // we don't want to keep resetting this value over and over again.
            // Especially when we start disabling other scripts because we're attached to the wall, such as jump.
            if (!onWallDetected){
                
                OnStick();
                ToggleScripts(false);
                onWallDetected = true;
            }
        } else {
            // if the last check was OnWallDetected = true 
            // disable that; reset our scripts; call OffWall 
            OffWall();
            ToggleScripts(true);
            onWallDetected = false;
        }       
    }

    protected virtual void OnStick(){
        if (!collisionState.standing && body2D.velocity.y > 0){
            body2D.gravityScale = 0;
            body2D.drag = 100;
        }
    }

    protected virtual void OffWall(){
        if(body2D.gravityScale != defaultGravityScale){
            body2D.gravityScale = defaultGravityScale;
            body2D.drag = defaultDrag;
        }
    }
}
