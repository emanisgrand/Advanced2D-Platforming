using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public Vector2 initialVelocity = new Vector2 (100,-100);
    
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

    // Update is called once per frame
    void Update() {
        
    }
}
