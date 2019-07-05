using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adding a comment to check git status test
public class SimpleMovement : MonoBehaviour
{
    public float speed;
    public Buttons[] input;
    
    private Rigidbody2D body2D;
    private InputState inputState;        // 🔣 This is a reference to the Game Object that the input script is attached to.  

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        inputState = GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update()
    {
        var right = inputState.GetButtonValue(input[0]);
        var left = inputState.GetButtonValue(input[1]);
        var velX = speed;

        if(right || left){
            velX *= left ? -1 : 1;
        } else {
             velX = 0;
        }
        body2D.velocity = new Vector2 (velX, body2D.velocity.y);
    }
}
