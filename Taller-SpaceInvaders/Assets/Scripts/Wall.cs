using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Command.Instance.Back = true;
            StartCoroutine("Switch");
        }
    }

    IEnumerator Switch()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSecondsRealtime(2);
        {
            GetComponent<BoxCollider>().enabled = true ;
        }
    }
}
