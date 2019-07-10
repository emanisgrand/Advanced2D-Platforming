using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour
{
    public LayerMask collisionLayer;  //the actual collision layer we'll be doing the tests with
    public bool standing;
    public bool onWall;
    public Vector2 bottomPosition = Vector2.zero; // the position or the point in space we want to actually test for a collision
     public Vector2 rightPosition = Vector2.zero;
    public Vector2 leftPosition = Vector2.zero; 
    public float collisionRadius = 10f; // the distance around this point for us to test collision
    public Color debugCollisionColor = Color.red;

    private InputState inputState;

    // Start is called before the first frame update
    void Awake() {
        inputState = GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        var pos = bottomPosition;  // relative to world space
        pos.x += transform.position.x; //offset this by the gameobject's actual position
        pos.y += transform.position.y;
        //Overlap the circle - in this case - the center point of our player, 
        //and the radius that we're defining up here and see if it's within 
        //this collisionLayer. If it is, it'll return true. If not, it'll return false.
        standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);

        pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;  
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        onWall = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);

    }

    private void OnDrawGizmos() {
        Gizmos.color = debugCollisionColor;

        var positions = new Vector2[] {rightPosition, bottomPosition, leftPosition};

        foreach (var position in positions) {
            var pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;
            Gizmos.DrawWireSphere(pos, collisionRadius);
        }
        

        
    }

}
