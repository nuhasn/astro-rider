using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementStrength;
    public GameObject camera;
    public int maxX;
    public int maxY;

    //Current score
    private int score;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        this.score = 0;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        if (Input.GetKey("up") && rb.transform.position.y < camera.transform.position.y + maxY)
            transform.position = new Vector2(this.transform.position.x, this.transform.position.y + movementStrength / 100);
        else if (Input.GetKey("down") && rb.transform.position.y > camera.transform.position.y - maxY)
            transform.position = new Vector2(this.transform.position.x, this.transform.position.y - movementStrength / 100);
        else if (Input.GetKey("left") && rb.transform.position.x > camera.transform.position.x - maxX)
            transform.position = new Vector2(this.transform.position.x - movementStrength / 100, this.transform.position.y);
        else if (Input.GetKey("right") && rb.transform.position.x < camera.transform.position.x + maxX)
            transform.position = new Vector2(this.transform.position.x + movementStrength / 100, this.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            this.score++;
            collision.gameObject.SetActive(false);
        }
    }
}