using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : AbstractBehavior
{
    // *public member variablels
    public GameObject projectilePrefab;
    public Vector2    firePosition  = Vector2.zero;
    public Color      debugColor    = Color.yellow;
    public float      debugRadius   = 0.3f;
    public float      shootDelay    = 0.5f;
    // ?private member variables
    private float     timeElapsed   = 0f;
    
    void Update()
    {
        if (projectilePrefab != null){
            var canFire = inputState.GetButtonValue(inputButtons[0]);

            if (canFire && timeElapsed > shootDelay){
                CreateProjectile(CalculateFirePosition()); // because CalculateFirePos is a Vector2 class, it's a valid parameter
                timeElapsed = 0;
            }
            timeElapsed += Time.deltaTime;
        }    
    }

    //Now we're gonna wanna be able to calculate the new position, based on the firePosition we set.
    Vector2 CalculateFirePosition(){
        var pos = firePosition;
        //Now we need to calculate where the firePosition goes, based on the direction our player is facing.
        pos.x *= (float)inputState.direction;  // always fire from the direction the character is facing (left/right)
        pos.x += transform.position.x;  //! I had this set to pos.x = trans- when it should be +=
        pos.y += transform.position.y;
        return pos;
    }
    
    public void CreateProjectile(Vector2 pos){
        /* //! cloning seems to be pretty common when it comes to the instantiation
        ! of prefabs. I think we did this same thing with the laser in the 2D Asteroid shooter
        ! if not the asteroids themselves from the spawner. Good thing to note */
        var clone = Instantiate (projectilePrefab, pos, Quaternion.identity) as GameObject;
        // set the clone's transform scale data.
        clone.transform.localScale = transform.localScale;
    }


    /* //! This method runs in the IDE before the game has actually started 
    ! there will not be a reference to inputState when you try to run the game */
    void OnDrawGizmos() {   
       Gizmos.color = debugColor;
        // 📋 Everuthing that's being done in CalculateFirePosition 
        var pos = firePosition;
        if (inputState != null)  //! this check makes it possible to see the use inputState's direction and see the firePosition change left and right 
            pos.x *= (float)inputState.direction; 
        pos.x += transform.position.x;
        pos.y += transform.position.y;
        
        Gizmos.DrawWireSphere(pos, debugRadius);
    }
}
