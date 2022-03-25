using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    // Uses "PlayerController" to refrence the player controller script because that is its Public Class name, other example would be Publc Class RepeatBackground or Public Class Spawn Manager
    private PlayerController playerControllerScript;
    private float leftBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        // Sets the playerControllerScript variable to be the actual player controller script
        // Starts by finding Player Game Object in the project heiarchy and then the player controller script attatched to it
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
