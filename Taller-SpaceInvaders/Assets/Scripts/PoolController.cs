using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    private static PoolController instance;
    [SerializeField] private Pool ovni, bullet, enemy1, enemy2, enemy3, speBullet;

    public static PoolController Instance
    {
        get { return instance; }
    }

    public Pool Bullet { get => bullet; set => bullet = value; }
    public Pool Enemy1 { get => enemy1; set => enemy1 = value; }
    public Pool Enemy2 { get => enemy2; set => enemy2 = value; }
    public Pool Enemy3 { get => enemy3; set => enemy3 = value; }
    public Pool Ovni { get => ovni; set => ovni = value; }
    public Pool SpeBullet { get => speBullet; set => speBullet = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
