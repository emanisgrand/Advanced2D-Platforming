using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// keep track of any of the button states
public class ButtonState{
    public bool value; // sees if the button is pressed or not
    public float holdTime = 0;
}

public enum  Directions{
    Right   =1,
    Left    =-1
}

public class InputState : MonoBehaviour
{
    public Directions direction = Directions.Right;
    
    // Let's keep an eye on what's actually going on with the rigidbody, and its velocity
    public float absVelX = 0f;
    public float absVelY = 0f;
    
    private Rigidbody2D body2D;
    private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();  // takes key: buttons enum and the value we created on line 6. instantiated in line
    
    private void Awake() {
        body2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        // This is intended to be used simply to know if there's actually 
        //motion in place. So in this case, by simply getting the absolute 
        //value I will know whether it's greater than zero or if it's at rest, 
        //which would equal zero.
        absVelX = Mathf.Abs(body2D.velocity.x);
        absVelY = Mathf.Abs(body2D.velocity.y);
    }

    void Update() {
        foreach(KeyValuePair<Buttons, ButtonState> state in buttonStates) { // KeyValuePair is used to iterate through the Dictionary list and return 
            Debug.Log("Button State "+state.Key+" "+state.Value.value);  // the keys and values from the it. States are what we're going to name each key.
        }    
    }

    public void SetButtonValue(Buttons key, bool value){ // This is going to do all the heavy lifting. Tell it which key to check for 
        if (!buttonStates.ContainsKey(key))    //and whether or not it has been pressed.
            buttonStates.Add(key, new ButtonState());  // if the key doesn't exist, add it as a new button state.

        var state = buttonStates [key];  // sets reference to the key from the dictionary to a variable we will use ecalled state.

        if (state.value && !value) {
            state.holdTime=0;
        } else if (state.value && value) {
            state.holdTime += Time.deltaTime;
        }

        //TODO:🔬 I think this is how the values are being set.
        state.value = value;               
    }

    public bool GetButtonValue(Buttons key) {  
        if (buttonStates.ContainsKey (key))       // if (or once) the dictionary has a key in it, 
            return buttonStates [key].value;      // this bool returns its value... to the console(🔬) I'm not sure what the purpose of this is.
         else 
            return false;
    }

    public float GetButtonHoldTime(Buttons key) {
        if (buttonStates.ContainsKey (key))
            return buttonStates [key].holdTime;
         else
            return 0; 
    }
}


