using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private AudioSource fxSound;
    public AudioClip explosion;
    public AudioClip powerUp;

    public float movementStrength;
    public GameObject camera;
    public int maxX;
    public int maxY;
    public GameObject scoreTextGO;
    public GameObject gameOverTextGO;
    public int health;
    public int asteroidHealthDeduction;
    public int batteryHealth;

    //Current score
    public int score;
    private Rigidbody2D rb;
    private Text scoreText;
    private Text gameOverText;
    private int nextScoreUpdate;

    // Use this for initialization
    void Start()
    {
        fxSound = GetComponent<AudioSource>();

        this.score = 0;
        this.nextScoreUpdate = 1;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        this.scoreText = scoreTextGO.GetComponent<Text>();
        gameOverText = gameOverTextGO.GetComponent<Text>();
        gameOverText.text = "";
        gameOverText.enabled = false;
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.health <= 0)
            gameOver();

        float x = 0;
        if (Input.GetKey("up") && rb.transform.position.y < camera.transform.position.y + maxY)
            transform.position = new Vector2(this.transform.position.x, this.transform.position.y + movementStrength / 100);
        if (Input.GetKey("down") && rb.transform.position.y > camera.transform.position.y - maxY)
            transform.position = new Vector2(this.transform.position.x, this.transform.position.y - movementStrength / 100);
        if (Input.GetKey("left") && rb.transform.position.x > camera.transform.position.x - maxX)
            transform.position = new Vector2(this.transform.position.x - movementStrength / 100, this.transform.position.y);
        if (Input.GetKey("right") && rb.transform.position.x < camera.transform.position.x + maxX)
            transform.position = new Vector2(this.transform.position.x + movementStrength / 100, this.transform.position.y);

        if (Time.time >= nextScoreUpdate)
        {
            nextScoreUpdate = Mathf.FloorToInt(Time.time) + 1;
            handleScore();
        }

    }
    
    private void SetScoreText()
    {
        scoreText.text = "Score: " + this.score.ToString();
    }
    
    private void handleScore()
    {
        this.score++;
        SetScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool play = false;
        if (collision.tag == "Hazard")
        {
            this.health = this.health - this.asteroidHealthDeduction;
            Destroy(collision.GetComponent<GameObject>());
            fxSound.clip = explosion;
            play = true;
        }
        if (collision.tag == "Battery" && this.health < 60)
        {
            this.health = this.health + this.batteryHealth;
            if (this.health > 60)
                this.health = 60;
            Destroy(collision.GetComponent<GameObject>());
            fxSound.clip = powerUp;
            play = true;
        }
        if (play)
            fxSound.Play();
    }

    private void gameOver()
    {
        this.gameOverText.text = "GAME OVER";
        this.gameOverText.enabled = true;
        this.gameObject.SetActive(false);
    }
}