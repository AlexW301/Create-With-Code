using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private bool facingRight = true;
    public float speed = 7f;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //   Reset moveDelta
        moveDelta = new Vector3(x, y, 0) * speed;

        // Sawp sprite direction whether you're going right or left

        if (moveDelta.x > 0 && !facingRight)
        {
            transform.localScale = Vector3.one;
            facingRight = true;
        }
        else if (moveDelta.x < 0 && facingRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        // Make this thing move!
        transform.Translate(moveDelta * Time.deltaTime);
    }
}


//    //Make sure we can move in this direction by casting a box ther first, if the box returns null we are free to move
//         hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
//         if (hit.collider == null)
//         {
//             // Make this thing move!
//             transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
//         }

//         hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.x), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
//         if (hit.collider == null)
//         {
//             // Make this thing move!
//             transform.Translate(0, moveDelta.x * Time.deltaTime, 0);
//         }