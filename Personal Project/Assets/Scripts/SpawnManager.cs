using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private bool spawnAnother = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xOffset = Random.Range(0, 150);
        float yOffset = Random.Range(0, 150);
        float zOffset = Random.Range(0, 5);
        if (spawnAnother)
        {
            Instantiate(obstacle, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z + zOffset), transform.rotation);
            spawnAnother = false;
            StartCoroutine(spawnCountdown());
        }
    }

    IEnumerator spawnCountdown()
    {
        yield return new WaitForSeconds(2);
        spawnAnother = true;
    }
}
