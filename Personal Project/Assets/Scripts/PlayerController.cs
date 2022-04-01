using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    private bool canShoot = true;
    public float moveSpeed;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        // GetComponent<Rigidbody>().AddForce(moveDirection, ForceMode.Impulse);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection));
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            Instantiate(projectile, new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z), projectile.transform.rotation);
            canShoot = false;
            StartCoroutine(projectileCountdownTimer());
        }

        IEnumerator projectileCountdownTimer()
        {
            yield return new WaitForSeconds(.6f);
            canShoot = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
        }
    }
}
