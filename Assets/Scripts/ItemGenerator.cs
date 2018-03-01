using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    // Item game object to generate.
    public GameObject[] asteroids;
    public GameObject battery;

    // Max item generation Y position.
    public int maxY;

    // Monitor next point that the item needs to generated at.
    private float nextAsteroidGenerationPoint;
    private float nextBatteryGenerationPoint;

    // Use this for initialization
    void Start () {
        this.nextAsteroidGenerationPoint = 1;
        this.nextBatteryGenerationPoint = 10;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextAsteroidGenerationPoint)
        {
            nextAsteroidGenerationPoint = (Time.time) + Random.Range(0.5f, 1);
            GameObject ob = (GameObject) Instantiate (asteroids[Random.Range(0,asteroids.Length)]);
            ob.SetActive(true);
            Vector2 position = this.transform.position;
            ob.transform.position = new Vector2(position.x, GameObject.FindWithTag("Player").transform.position.y);
        }
        if (Time.time >= nextBatteryGenerationPoint)
        {
            nextBatteryGenerationPoint = (Time.time) + Random.Range(3, 7);
            GameObject ob = (GameObject)Instantiate(battery);
            ob.SetActive(true);
            Vector2 position = this.transform.position;
            ob.transform.position = new Vector2(position.x, position.y + Random.Range(-maxY,maxY));
        }
    }
}
