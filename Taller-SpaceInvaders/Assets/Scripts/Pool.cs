using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject thingPrefab;
    [SerializeField] private int size;
    private List<GameObject> things;

    private void Start()
    {
        MakeThings();
    }

    private void AddThings()
    {
        GameObject thing = Instantiate(thingPrefab);
        thing.gameObject.SetActive(false);
        things.Add(thing);
    }

    private void MakeThings()
    {
        things = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            AddThings();
        }
    }

    private GameObject RemoveThing()
    {
        GameObject thing = things[things.Count - 1];
        things.RemoveAt(things.Count - 1);
        return thing;
    }

    public GameObject GetThing()
    {
        if (things.Count == 0)
            AddThings();
        return RemoveThing();
    }

    public void ReleaseThing(GameObject thing)
    {
        thing.gameObject.SetActive(false);
        thing.transform.position = transform.position;
        things.Add(thing);
    }
}
