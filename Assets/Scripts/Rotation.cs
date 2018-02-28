using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    public float rotationSpeed;
    private Vector3 rotationDirecton;
    private Vector3[] directions = { new Vector3(0, 0, 1), new Vector3(0, 0, -1) };

	// Use this for initialization
	void Start () {
        rotationSpeed = Random.Range(120,150);
        rotationDirecton = directions[Random.Range(0, 2)];
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(rotationDirecton * rotationSpeed * Time.deltaTime);
    }
}
