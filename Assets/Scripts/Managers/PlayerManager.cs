using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputState inputState;
    private Walk walkBehavior;
    private Animator animator;

    void Awake() {
        inputState = GetComponent<InputState>();
        walkBehavior = GetComponent<Walk>();
        animator = GetComponent<Animator>();
    }       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputState.absVelX == 0){
            ChangeAnimationState(0);  
        }

        if (inputState.absVelX > 0)
        {
            ChangeAnimationState(1); // this will be set to our walk animation later.
        }
    }

    // Change the state of the animation based on the value being detected.
    void ChangeAnimationState(int value){
            animator.SetInteger("AnimState", value);
    }
}
