using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputState inputState;
    private Walk walkBehavior;
    private Animator animator;
    private CollisionState collisionState;
    private Duck duckState;

    void Awake() {
        inputState = GetComponent<InputState>();
        walkBehavior = GetComponent<Walk>();
        animator = GetComponent<Animator>();
        collisionState = GetComponent<CollisionState>();
        duckState = GetComponent<Duck>();
    }       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionState.standing)  // there may be times when the absolute value of X actually equals zero, if you're in the middle of a jump.
            ChangeAnimationState(0);  
        if (inputState.absVelX > 0)
            ChangeAnimationState(1);  // this will be set to our walk animation later.
        if (inputState.absVelY > 0)
            ChangeAnimationState(2);  // Animator is set to transition the jump anim at this value
        animator.speed = walkBehavior.running ? walkBehavior.runMultiplier : 1;
        if (duckState.ducking){
            ChangeAnimationState(3);
        }
    }
    
    // Change the state of the animation based on the value being detected.
    void ChangeAnimationState(int value){
            animator.SetInteger("AnimState", value);
    }
}
