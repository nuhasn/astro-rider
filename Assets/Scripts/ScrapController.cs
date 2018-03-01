using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapController : MonoBehaviour
{
    private PlayerController player;
    public Sprite meter0;
    public Sprite meter1;
    public Sprite meter2;
    public Sprite meter3;
    public Sprite meter4;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = meter0;
    }

    // Update is called once per frame
    void Update()
    {
        Sprite prev = spriteRenderer.sprite;
        int h = player.scrap % 5;
        if (h < 1)
            spriteRenderer.sprite = meter0;
        else if (h < 2)
            spriteRenderer.sprite = meter1;
        else if (h < 3)
            spriteRenderer.sprite = meter2;
        else if (h < 4)
            spriteRenderer.sprite = meter3;
        else if (h < 5)
            spriteRenderer.sprite = meter4;
    }
}
