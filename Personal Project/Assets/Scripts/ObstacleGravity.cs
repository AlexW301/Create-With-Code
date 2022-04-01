using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGravity : MonoBehaviour
{
    public GravityAroundPlayer attractorPlanet;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void Update()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(playerTransform);
        }
    }
}