using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float speed = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
    }
}
