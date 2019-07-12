using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string targetTag = "Player";

    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == targetTag) {  // checking if its colliding with the targetag
            OnCollect(target.gameObject);  //run the OnCollect function
            OnDestroy();
        }    
    }
    
    protected virtual void OnCollect(GameObject target){

    }

    protected virtual void OnDestroy() {
        Destroy(gameObject);
    }
}
