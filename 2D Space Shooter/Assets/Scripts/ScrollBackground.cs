using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Vector3 startPos;
    private int speed = 5;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < repeatWidth - startPos.y)
        {
            transform.position = startPos;
        }

        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
