using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehavior : MonoBehaviour  //added the abstract keyword. Not allowed to instantiate directly. Hides from search
{
    public Buttons[] inputButtons;

    protected InputState inputState;  // private yet available to other classes that extend it
    protected Rigidbody2D body2D;
    protected CollisionState collisionState;

    protected virtual void Awake() {
        inputState = GetComponent<InputState>();
        body2D = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
