using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeBullet : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (0.1f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shield")
        {
            Destroy(other.gameObject);

        }
        else if (other.tag == "Enemy")
        {
            GameManager.Instance.Points = GameManager.Instance.Points + other.GetComponent<Enemy>().Points;
            GameManager.Instance.Kills++;
            other.GetComponent<Enemy>().ReturnToPool();
        }
        else if(other.tag == "Limit")
        {
            PoolController.Instance.SpeBullet.ReleaseThing(gameObject);
        }        
    }
}
