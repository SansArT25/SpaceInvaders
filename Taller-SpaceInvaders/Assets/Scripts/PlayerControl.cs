using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 2.3 && transform.position.x >= -2.3)
        {
            transform.position = new Vector3(transform.position.x + (Input.acceleration.x / 10), transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 2.3)
        {
            if (Input.acceleration.x < 0)
            {
                transform.position = new Vector3(transform.position.x + (Input.acceleration.x / 10), transform.position.y, transform.position.z);
            }
        }
        else if (transform.position.x < -2.3)
        {
            if (Input.acceleration.x > 0)
            {
                transform.position = new Vector3(transform.position.x + (Input.acceleration.x / 10), transform.position.y, transform.position.z);

            }
        }
    }
}
