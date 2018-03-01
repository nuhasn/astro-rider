using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    public float rotationSpeed;
    private Vector3 rotationDirecton;

	// Use this for initialization
	void Start () {
        rotationSpeed = 15;
		rotationDirecton = new Vector3 (0, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(rotationDirecton * rotationSpeed * Time.deltaTime);
    }
}
