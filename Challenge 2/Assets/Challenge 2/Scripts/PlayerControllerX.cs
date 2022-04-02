using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public static float time = 0.5f;
    public float timer = time;

    // Update is called once per frame
    void Update()
    {
        // Runs timer
        timer -= Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timer < 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            // Reset timer
            timer = time;
        }
    }
}
