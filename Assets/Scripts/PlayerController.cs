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
    public GameObject factTextGO;
    public int health;
    public int asteroidHealthDeduction;
    public int batteryHealth;

    //Current score
    public int score;
    private Rigidbody2D rb;
    private Text scoreText;
    private int nextScoreUpdate;

    // Use this for initialization
    void Start()
    {
        fxSound = GetComponent<AudioSource>();

        this.score = 0;
        this.nextScoreUpdate = 1;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        this.scoreText = scoreTextGO.GetComponent<Text>();

        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        if (Input.GetKey("up") && rb.transform.position.y < camera.transform.position.y + maxY)
            transform.position = new Vector2(this.transform.position.x, this.transform.position.y + movementStrength / 100);
        if (Input.GetKey("down") && rb.transform.position.y > camera.transform.position.y - maxY)
            transform.position = new Vector2(this.transform.position.x, this.transform.position.y - movementStrength / 100);
        if (Input.GetKey("left") && rb.transform.position.x > camera.transform.position.x - maxX)
            transform.position = new Vector2(this.transform.position.x - movementStrength / 100, this.transform.position.y);
        if (Input.GetKey("right") && rb.transform.position.x < camera.transform.position.x + maxX)
            transform.position = new Vector2(this.transform.position.x + movementStrength / 100, this.transform.position.y);

        if (this.health <= 0)
            gameOver();


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
            fxSound.clip = explosion;
            play = true;
        }
        if (collision.tag == "Battery" && this.health < 60)
        {
            this.health = this.health + this.batteryHealth;
            if (this.health > 60)
                this.health = 60;
            
            fxSound.clip = powerUp;
            play = true;
        }
        if (play)
            fxSound.Play();
        Destroy(collision.GetComponent<GameObject>());
    }

	private string getFacts() {
		List<string> vehicleFacts = new List<string> {
			"Bicycle: Top Speed 245km/h, Invented 1817, Mass ~10kg\n",
			"Roadster: Top Speed 125mph, Invented 2008, Mass 1305kg\n",
			"Spitfire: Top Speed 584km/h, Invented 1936, Mass 1965kg\n",
			"Boeing 747: Top Speed 933km/h, Invented 1969, Mass 220128kg\n",
			"Boeing Starliner: Top Speed ???, Invented 2018, Mass 13000kg\n",
			"X-Wing: Only one X-Wing pilot survived the original trilogy\n"
		};
		List<string> planetFacts = new List<string> {
			"Moon: Distance to Earth: 384,400 km, Age: 4.53 billion years, Orbital period: 27 days\n",
			"Mars: Mass: 6.39 × 10^23 kg, Distance from Sun: 227.9 million km, Length of day: 1d 0h 37m\n",
			"Jupiter: Distance from Sun: 778.5 million km, Mass: 1.898 × 10^27 kg, Length of day: 0d 9h 56m\n",
			"Saturn: Distance from Sun: 1.429 billion km, Mass: 5.683 × 10^26 kg, Length of day: 0d 10h 42m\n",
			"Uranus: Distance from Sun: 2.871 billion km, Mass: 8.681 × 10^25 kg, Length of day: 0d 17h 14m\n",
			"Neptune: Distance from Sun: 4.498 billion km, Mass: 1.024 × 10^26 kg, Length of day: 0d 16h 6m\n"
		};

		string facts = "FUN FACTS:\n";
		for (int i = 0; i < 6; i++) {
			if (score >= 10 * i) {
				Debug.Log (i);
				facts += (vehicleFacts [i]);
				facts += (planetFacts [i]);
			} else break;
		}
		Debug.Log (facts);

		return facts;
	}

    private void gameOver()
    {
        Text factText = factTextGO.GetComponent<Text>();
		factText.text = getFacts();

		Text gameOverText = gameOverTextGO.GetComponent<Text>();
		gameOverText.text = "GAME OVER";
		Debug.Log (gameOverText.fontSize);

        this.gameObject.SetActive(false);
    }
}