using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileForce : MonoBehaviour
{
    private Rigidbody projectileRb;
    private int speed = 10000;
    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
        projectileRb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
