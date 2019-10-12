using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            GameManager.Instance.LoseLife();
            GameManager.Instance.LoseLife();
            GameManager.Instance.LoseLife();
        }
    }
}
