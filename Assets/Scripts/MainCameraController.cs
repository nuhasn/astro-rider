using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {
    public GameObject objectToFollow;

    private float distanceToTarget;

	// Use this for initialization
	void Start () {
        float targetPosition = objectToFollow.transform.position.x;
        distanceToTarget = targetPosition - transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        float targetPosition = objectToFollow.transform.position.x;

        Vector3 cameraPosition = transform.position;
        
        cameraPosition.x = targetPosition - distanceToTarget;
        transform.position = cameraPosition;
	}
}
