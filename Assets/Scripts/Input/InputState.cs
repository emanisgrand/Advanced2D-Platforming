using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// keep track of any of the button states
public class ButtonState{
    public bool value; // sees if the button is pressed or not
}

public enum  Directions{
    Right   =1,
    Left    =-1
}

public class InputState : MonoBehaviour
{
    public Directions direction = Directions.Right;

    public Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();  // takes key: buttons enum and the value we created on line 6. instantiated in line
    
    void Update() {
        foreach(KeyValuePair<Buttons, ButtonState> state in buttonStates) { // KeyValuePair is used to iterate through the Dictionary list and return 
            Debug.Log("Button State "+state.Key+" "+state.Value.value);  // the keys and values from the it. States are what we're going to name each key.
        }    
    }

    public void SetButtonValue(Buttons key, bool value){ // This is going to do all the heavy lifting. Tell it which key to check for 
        if (!buttonStates.ContainsKey(key))    //and whether or not it has been pressed.
            buttonStates.Add(key, new ButtonState());  // if the key doesn't exist, add it as a new button state.

        var state = buttonStates [key];  // sets reference to the key from the dictionary to a variable we will use ecalled state.

        // if (state.value && !value) {
        //     
        // } else if (state.value && value) {
        //     
        // }

        //TODO:🔬 I think this is how the values are being set.
        state.value = value;               
    }

    public bool GetButtonValue(Buttons key){  
        if (buttonStates.ContainsKey(key)){       // if (or once) the dictionary has a key in it, 
            return buttonStates [key].value;      // this bool returns its value... to the console(🔬) I'm not sure what the purpose of this is.
        } else 
            return false;
    }
        
}


