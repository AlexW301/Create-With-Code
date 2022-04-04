using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed = 15.0f;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        Vector3 horizontalInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += horizontalInput * Time.deltaTime * speed;

        // Vertical Movement
        Vector3 verticalInput = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
        transform.position += verticalInput * Time.deltaTime * speed;

        // Sets animator parameter to trigger walking animation
        animator.SetFloat("Speed", horizontalInput.magnitude + verticalInput.magnitude);

        //Flips Character when walking
        float horizontalDirection = Input.GetAxis("Horizontal");
        if (horizontalDirection < 0 && facingRight)
        {
            Flip();
        }
        else if (horizontalDirection > 0 && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }

}

//  inputHorizontal = Input.GetAxis("Horizontal");
// inputVertical = Input.GetAxis("Vertical");

// if (inputHorizontal != 0)
// {
//     rb.AddForce(new Vector2(inputHorizontal * speed, 0f));
// }

// if (inputVertical != 0)
// {
//     rb.AddForce(new Vector2(inputVertical * speed, 0f));
// }