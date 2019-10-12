using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private float timeSwipe, timeRush;
    private bool canSwipe, canRush, canShoot, rushing;

    public float TimeSwipe { get => timeSwipe; set => timeSwipe = value; }
    public float TimeRush { get => timeRush; set => timeRush = value; }

    private void Start()
    {
        canSwipe = true;
        canRush = true;
        canShoot = true;
        rushing = false;
    }

    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(canSwipe && touch.phase == TouchPhase.Moved)
            {
                SpeShot();
            }
            else if(touch.phase == TouchPhase.Began)
            {
                Shoot();
            }
        }
        else if (canRush && Input.touchCount == 3)
        {
            Touch touch = Input.GetTouch(2);
            if(touch.phase == TouchPhase.Began)
            {
                StartCoroutine("Rush");
            }
        }

        if(rushing)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if(canShoot)
        {
            GameObject bullet = PoolController.Instance.Bullet.GetThing();
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.4f);
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().Dir = 1;
            StartCoroutine("ShootWait");
        }
    }

    private void SpeShot()
    {
        canSwipe = false;
        GameObject bullet = PoolController.Instance.SpeBullet.GetThing();
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.4f);
        bullet.SetActive(true);
        timeSwipe = 60;
        StartCoroutine("SwipeWait");
    }

    IEnumerator ShootWait()
    {
        canShoot = false;
        yield return new WaitForSecondsRealtime(0.1f);
        canShoot = true;
    }

    IEnumerator Rush()
    {
        rushing = true;
        canRush = false;
        yield return new WaitForSecondsRealtime(3);
        timeRush = 30;
        rushing = false;
        StartCoroutine("RushWait");
    }

    IEnumerator RushWait()
    {
        yield return new WaitForSecondsRealtime(1);
        timeRush--;
        if(timeRush == 0)
        {
            canRush = true;
        }
        else
        {
            StartCoroutine("RushWait");
        }
    }

    IEnumerator SwipeWait()
    {
        yield return new WaitForSecondsRealtime(1);
        timeSwipe--;
        if (timeSwipe == 0)
        {
            canSwipe = true;
        }
        else
        {
            StartCoroutine("SwipeWait");
        }
    }
}
