using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int dir;

    public int Dir { get => dir; set => dir = value; }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (dir * 0.1f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shield")
        {
            Destroy(other.gameObject);

        }
        else if (other.tag == "Enemy")
        {
            GameManager.Instance.Points = GameManager.Instance.Points + other.GetComponent<Enemy>().Points;
            GameManager.Instance.Kills++;
            other.GetComponent<Enemy>().ReturnToPool();
        }
        else if(other.tag == "Player")
        {
            GameManager.Instance.Shots--;
            GameManager.Instance.LoseLife();
        }

        GameManager.Instance.Shots++;
        PoolController.Instance.Bullet.ReleaseThing(gameObject);
    }
}