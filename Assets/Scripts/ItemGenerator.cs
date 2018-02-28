using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    // Item game object to generate.
    public GameObject item;

    // Max item generation Y position.
    public int maxY;

    // Monitor next point that the item needs to generated at.
    private int nextGenerationPoint;

	// Use this for initialization
	void Start () {
        this.nextGenerationPoint = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextGenerationPoint)
        {
            nextGenerationPoint = Mathf.FloorToInt(Time.time) + 1;
            GameObject ob = (GameObject) Instantiate (item);
            ob.SetActive(true);
            Vector2 position = this.transform.position;
            ob.transform.position = new Vector2(position.x, Random.Range(position.y - maxY, position.y + maxY));
        }
    }
}
