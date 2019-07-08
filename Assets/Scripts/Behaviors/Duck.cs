using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : AbstractBehavior {
    // public members
    public float                scale           =0.5f;
    public float                centerOffsetY   =0.0f;
    public bool                 ducking;
  
    // private members
    private CircleCollider2D    circleCollider;
    private Vector2             originalCenter;
    
    protected override void Awake(){
        base.Awake();

        circleCollider = GetComponent<CircleCollider2D>();
        originalCenter = circleCollider.offset;
    }

    protected virtual void OnDuck (bool value){
        
        ducking = value;

        var size = circleCollider.radius;
        // allow us to switch between the two different sizes. 
        float newOffSetY;
        float sizeReciprocal;
    
        if (ducking){
            sizeReciprocal = scale;
            newOffSetY = circleCollider.offset.y - size /2 + centerOffsetY;
        } else {
            sizeReciprocal = 1/scale;   //gives us the reciprocal of that value
            newOffSetY = originalCenter.y;
        }

        size = size * sizeReciprocal;
        circleCollider.radius = size;
        circleCollider.offset = new Vector2 (circleCollider.offset.x, newOffSetY);  //modify the offset to take into account the change in the values.
    }

    void Update() {
        // Make sure that we only reset OnDuck to flase if we're actually ducking. 
        // If not, we'd wind up setting up this size calculation on every update loop, 
        // and this would have a negative performance impact to our game.
        var canDuck = inputState.GetButtonValue (inputButtons [0]);
        if(canDuck && collisionState.standing && !ducking){
            OnDuck(true);
        } else if (ducking && !canDuck) {
            OnDuck(false);
        }
    }
}
