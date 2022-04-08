using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private bool facingRight = true;
    public float speed = 7f;
    private RaycastHit2D hit;
    protected float ySpeed = 4f;
    protected float xSpeed = 5f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        //   Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

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
