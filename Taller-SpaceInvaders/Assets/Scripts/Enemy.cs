using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int points, type;

    public int Points { get => points; set => points = value; }

    public void ReturnToPool()
    {
        Command.Instance.Active--;
        if (type == 1)
        {
            PoolController.Instance.Enemy1.ReleaseThing(gameObject);
        }
        else if (type == 2)
        {
            PoolController.Instance.Enemy2.ReleaseThing(gameObject);
        }
        else if (type == 3)
        {
            PoolController.Instance.Enemy3.ReleaseThing(gameObject);
        }
    }

    public void Shoot()
    {
        GameObject bullet = PoolController.Instance.Bullet.GetThing();
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.4f);
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().Dir = -1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shield")
        {
            Destroy(collision.gameObject);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
