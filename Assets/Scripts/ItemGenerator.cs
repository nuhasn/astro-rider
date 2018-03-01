using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    // Item game object to generate.
    public GameObject[] asteroids;
    public GameObject battery;
    public GameObject scrapMetal;

    public PlayerController Player;

    public float spacing;

    public GameObject levelController;

    private LevelController lc;

    // Max item generation Y position.
    public int maxY;

    // Monitor next point that the item needs to generated at.
    private float nextAsteroidGenerationPoint;
    private float nextBatteryGenerationPoint;
    private float nextscrapMetalGenerationPoint;

    // Use this for initialization
    void Start () {
        lc = levelController.GetComponent<LevelController>();
        this.nextAsteroidGenerationPoint = 1;
        this.nextBatteryGenerationPoint = 10;
        this.nextscrapMetalGenerationPoint = 5;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextAsteroidGenerationPoint)
        {
            nextAsteroidGenerationPoint = (Time.time) + Random.Range(0.5f,2);
            GameObject ob = (GameObject) Instantiate (asteroids[Random.Range(0,asteroids.Length)]);
            ob.SetActive(true);
            Vector2 position = this.transform.position;
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null)
            {
                ob.transform.position = new Vector2(position.x, GameObject.FindWithTag("Player").transform.position.y);
                if (lc.currentLevel >= 3 && Random.Range(0,4) == 1)
                {
                    GameObject ob1 = (GameObject)Instantiate(asteroids[Random.Range(0, asteroids.Length)]);
                    ob1.SetActive(true);
                    ob1.transform.position = new Vector2(position.x, position.y + Random.Range(-maxY, maxY));
                }
            }
            else
                ob.transform.position = new Vector2(position.x, position.y + Random.Range(-maxY, maxY));
            float f = Random.Range(0.7f, 1.5f);
            ob.transform.localScale = new Vector2(f, f);
        }
        if (Time.time >= nextBatteryGenerationPoint)
        {
            nextBatteryGenerationPoint = (Time.time) + Random.Range(3, 7);
            GameObject ob = (GameObject)Instantiate(battery);
            ob.SetActive(true);
            Vector2 position = this.transform.position;
            ob.transform.position = new Vector2(position.x, position.y + Random.Range(-maxY,maxY));
        }
        if (Time.time >= nextscrapMetalGenerationPoint)
        {
            nextscrapMetalGenerationPoint = (Time.time) + Random.Range(2, 6);
            GameObject ob = (GameObject)Instantiate(scrapMetal);
            ob.SetActive(true);
            Vector2 position = this.transform.position;
            ob.transform.position = new Vector2(position.x, position.y + Random.Range(-maxY, maxY));
        }
    }
}
