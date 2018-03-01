using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {
    private PlayerController player;
    public Sprite percent_100;
    public Sprite percent_84;
    public Sprite percent_68;
    public Sprite percent_52;
    public Sprite percent_36;
    public Sprite percent_20;
    public Sprite percent_0;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = percent_100;
    }
	
	// Update is called once per frame
	void Update () {
        Sprite prev = spriteRenderer.sprite;
        int h = player.health;
        if (h >= 60)
            spriteRenderer.sprite = percent_100;
        else if (h >= 50)
            spriteRenderer.sprite = percent_84;
        else if (h >= 40)
            spriteRenderer.sprite = percent_68;
        else if (h >= 30)
            spriteRenderer.sprite = percent_52;
        else if (h >= 20)
            spriteRenderer.sprite = percent_36;
        else if (h >= 10)
            spriteRenderer.sprite = percent_20;
        else if (h >= 0)
            spriteRenderer.sprite = percent_0;
    }

}
