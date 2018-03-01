using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public Sprite[] planets;
    public Sprite[] players;
    public GameObject currentPlayer;
    public int[] levelScoreThresholds;

    public int currentLevel;
    private PlayerController player;

    private SpriteRenderer planet_sr;
    private SpriteRenderer player_sr;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        player_sr = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        planet_sr = GameObject.FindWithTag("Planet").GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (planet_sr.sprite == null)
        {// if the sprite on spriteRenderer is null then
            planet_sr.sprite = planets[0];
            currentPlayer.AddComponent<PolygonCollider2D>();
        }

        currentLevel = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (this.currentLevel < levelScoreThresholds.Length && player.score >= levelScoreThresholds[currentLevel])
        {
                planet_sr.sprite = planets[currentLevel + 1];
            player_sr.sprite = players[currentLevel + 1];
          //  Vector2 p = currentPlayer.transform.position;
                //Destroy(currentPlayer.gameObject);
          //      this.currentPlayer = (GameObject) Instantiate(players[currentLevel + 1]);
          //      currentPlayer.SetActive(true);
          //      currentPlayer.transform.position = p;
            currentLevel++;
        }
	}
}
