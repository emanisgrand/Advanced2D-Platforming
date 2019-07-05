using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehavior
{
    public float speed          =50f;
    public float runMultiplier  = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // set up the states to be reachable
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);

        if (right || left){
            var tmpSpeed = speed; 

            if (run && runMultiplier > 0){
                tmpSpeed *= runMultiplier;
            }

            var velX = tmpSpeed * (float)inputState.direction;   // convert the direction enum from the inputState to a float value.
            body2D.velocity = new Vector2(velX, body2D.velocity.y);  // calculate the total velocity of our sprite movement.

        }
    }
}
