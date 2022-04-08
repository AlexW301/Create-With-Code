using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
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