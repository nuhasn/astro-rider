using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour {
    public int startVelocity;
    public float acceleration;
    public int maximumVelocity;

    //The acceleration to be applied to the falling player.
    private float acc;
    //The current velocity of the player falling downwards.
    private float velocity;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        this.acc = acceleration / 1000;
        this.velocity = this.startVelocity;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocity, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (velocity < maximumVelocity)
            velocity = velocity + acc;

        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }
}
