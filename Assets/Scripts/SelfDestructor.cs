using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    // Destroy the object after it reaches this point.
    private GameObject destructPoint;

    // Use this for initialization
    void Start()
    {
        destructPoint = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < destructPoint.transform.position.x)
        {
            Debug.Log("here");
            Destroy(gameObject);
        }
    }
}
