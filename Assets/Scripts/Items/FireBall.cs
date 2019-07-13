using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public Vector2      initialVelocity = new Vector2 (100,-100);
    public int          bounces         = 3;
    
    private Rigidbody2D body2D;

    private void Awake() {
        body2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {

        var startVelX = initialVelocity.x * transform.localScale.x;
        // This is how the fireball will move once it's instantiated.
        body2D.velocity = new Vector2 (startVelX, initialVelocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D target) {
        //  if the object we're colliding with is lower than the fireball.
        if (target.gameObject.transform.position.y < transform.position.y){
            bounces--;
        }   

        if (bounces <= 0){
            Destroy(gameObject);
        }
    }
}
