using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehavior : MonoBehaviour  //added the abstract keyword. Not allowed to instantiate directly. Hides from search
{
    public Buttons[] inputButtons;
    public MonoBehaviour[] disableScripts; // we don't want our behaviors to actually know anything about other behaviors. All we want them to know is that at some point they can loop through all the scripts that are associated with it, and disable and enable them based on its own state

    protected InputState inputState;  // private yet available to other classes that extend it
    protected Rigidbody2D body2D;
    protected CollisionState collisionState;

    protected virtual void Awake() {
        inputState = GetComponent<InputState>();
        body2D = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

    protected virtual void ToggleScripts (bool value){
        foreach (var script in disableScripts) {  // Drag a script from the inspector to the array reference 
            script.enabled = value;
        }
    }
}
