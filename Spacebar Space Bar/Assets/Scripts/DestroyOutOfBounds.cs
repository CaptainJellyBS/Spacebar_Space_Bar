using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float horBound = 35, verBound = 16;
    bool hasBeenInBounds;

    private void Start()
    {
        hasBeenInBounds = !(transform.position.x < -horBound || transform.position.x > horBound || transform.position.z < -verBound || transform.position.z > verBound);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -horBound || transform.position.x > horBound || transform.position.z < -verBound || transform.position.z > verBound)
        {
            if(hasBeenInBounds) { Destroy(gameObject); }
        }
        else
        {
            hasBeenInBounds = true;
        }
    }
}
