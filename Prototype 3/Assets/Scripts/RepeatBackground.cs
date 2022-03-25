using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        // Sets the start position to whatever the tranform position of the background starts at
        startPos = transform.position;
        // Set repeat width based on the box collider components width
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x  < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
