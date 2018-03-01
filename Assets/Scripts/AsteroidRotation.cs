using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour {
    public float rotationSpeed;
    private Vector3 rotationDirecton;
    private Vector3[] directions = { new Vector3(0, 0, 1), new Vector3(0, 0, -1) };
    private float angle;

	// Use this for initialization
	void Start () {
        rotationSpeed = Random.Range(120,150);
        rotationDirecton = directions[Random.Range(0, 2)];
        angle = Random.Range(-0.01f, 0.01f);
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(rotationDirecton * rotationSpeed * Time.deltaTime);
        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + angle);
    }
}
