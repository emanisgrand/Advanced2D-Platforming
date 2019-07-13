using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : AbstractBehavior
{
    public float shootDelay = 0.5f;
    public GameObject projectilePrefab;

    private float timeElapsed = 0f;
    
    void Update()
    {
        if (projectilePrefab != null){
            var canFire = inputState.GetButtonValue(inputButtons[0]);

            if (canFire && timeElapsed > shootDelay){
                CreateProjectile(transform.position);
                timeElapsed = 0;
            }
            timeElapsed += Time.deltaTime;
        }    
    }

    public void CreateProjectile(Vector2 pos){
        /* //! cloning seems to be pretty common when it comes to the instantiation
        ! of prefabs. I think we did this same thing with the laser in the 2D Asteroid shooter
        ! if not the asteroids themselves from the spawner. Good thing to note */
        var clone = Instantiate (projectilePrefab, pos, Quaternion.identity) as GameObject;
        // set the clone's transform scale data.
        clone.transform.localScale = transform.localScale;
    }

}
