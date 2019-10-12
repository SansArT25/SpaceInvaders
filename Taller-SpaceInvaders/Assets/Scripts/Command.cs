using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    private static Command instance;
    private bool prepared, deadLine, back;
    private List<GameObject> lines, line1, line2, line3, line4, line5, actives;
    private int dir, active;

    public static Command Instance
    {
        get { return instance; }
    }

    public bool Back { get => back; set => back = value; }
    public int Active { get => active; set => active = value; }

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

    // Start is called before the first frame update
    void Start()
    {
        prepared = false;
        deadLine = false;
        back = false;
        lines = new List<GameObject>();
        line1 = new List<GameObject>();
        line2 = new List<GameObject>();
        line3 = new List<GameObject>();
        line4 = new List<GameObject>();
        line5 = new List<GameObject>();
        actives = new List<GameObject>();
        dir = -1;
        active = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Playing)
        {
            if (!prepared)
            {
                for (int i = 0; i < 6; i++)
                {
                    lines.Add(PoolController.Instance.Enemy3.GetThing());
                    lines[i].transform.position = new Vector3(-1.875f + (0.75f * i), 1, 3);
                    line1.Add(lines[i]);
                    lines[i].SetActive(true);
                    active++;
                }

                for (int i = 6; i < 12; i++)
                {
                    lines.Add(PoolController.Instance.Enemy2.GetThing());
                    lines[i].transform.position = new Vector3(-1.875f + (0.75f * (i - 6)), 1, 2.25f);
                    line2.Add(lines[i]);
                    lines[i].SetActive(true);
                    active++;
                }

                for (int i = 12; i < 18; i++)
                {
                    lines.Add(PoolController.Instance.Enemy2.GetThing());
                    lines[i].transform.position = new Vector3(-1.875f + (0.75f * (i - 12)), 1, 1.5f);
                    line3.Add(lines[i]);
                    lines[i].SetActive(true);
                    active++;
                }
                for (int i = 18; i < 24; i++)
                {
                    lines.Add(PoolController.Instance.Enemy1.GetThing());
                    lines[i].transform.position = new Vector3(-1.875f + (0.75f * (i - 18)), 1, 0.75f);
                    line4.Add(lines[i]);
                    lines[i].SetActive(true);
                    active++;
                }

                for (int i = 24; i < 30; i++)
                {
                    lines.Add(PoolController.Instance.Enemy1.GetThing());
                    lines[i].transform.position = new Vector3(-1.875f + (0.75f * (i - 24)), 1, 0);
                    line5.Add(lines[i]);
                    actives.Add(lines[i]);
                    lines[i].SetActive(true);
                    active++;
                }
                
                StartCoroutine("Move");
                StartCoroutine("Shoot");
                prepared = true;
            }

            for (int i = 0; i < 6; i++)
            {
                if (!actives[i].activeInHierarchy)
                {

                    if (lines[lines.Count + i - 12].activeInHierarchy)
                    {
                        actives[i] = lines[lines.Count + i - 12];
                    }
                    else if (lines[lines.Count + i - 18].activeInHierarchy)
                    {
                        actives[i] = lines[lines.Count + i - 18];
                    }
                    else if (lines[lines.Count + i - 24].activeInHierarchy)
                    {
                        actives[i] = lines[lines.Count + i - 24];
                    }
                    else if (lines[lines.Count + i - 30].activeInHierarchy)
                    {
                        actives[i] = lines[lines.Count + i - 30];
                    }
                }
            }

            if(!deadLine)
            {
                deadLine = true;
                for (int i = 0; i < 6; i++)
                {
                    if (line5[i].activeInHierarchy)
                    {
                        deadLine = false;
                    }
                }
            }
            else
            {
                for (int i = 24; i < 30; i++)
                {
                    lines[i] = lines[i - 6];
                }
                for (int i = 18; i < 24; i++)
                {
                    lines[i] = lines[i - 6];
                    line4[i - 18] = lines[i];
                }
                for (int i = 12; i < 18; i++)
                {
                    lines[i] = lines[i - 6];
                    line3[i - 12] = lines[i];
                }
                for (int i = 6; i < 12; i++)
                {
                    lines[i] = lines[i - 6];
                    line2[i - 6] = lines[i];
                }
                for (int i = 0; i < 6; i++)
                {
                    lines[i] = line5[i];
                    if(lines[i].activeInHierarchy)
                    {
                        lines[i].SetActive(false);
                        active--;
                    }
                    line1[i] = lines[i];
                    line5[i] = lines[i + 24];
                    if(line2[i].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i].transform.position.x, line2[i].transform.position.y, line2[i].transform.position.z + 0.75f);
                    }
                    else if((i == 1 || i == 2 || i == 3 || i == 0) && line2[i + 1] != null && line2[i + 1].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i + 1].transform.position.x - 0.75f, line2[i + 1].transform.position.y, line2[i + 1].transform.position.z + 0.75f);
                    }
                    else if ((i == 1 || i == 2 || i == 0) && line2[i + 2] != null && line2[i + 2].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i + 2].transform.position.x - 1.5f, line2[i + 2].transform.position.y, line2[i + 2].transform.position.z + 0.75f);
                    }              
                    else if ((i == 1|| i == 0) && line2[i + 3] != null && line2[i + 3].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i + 3].transform.position.x - 2.75f, line2[i + 3].transform.position.y, line2[i + 3].transform.position.z + 0.75f);
                    }
                    else if (i == 0 && line2[i + 4] != null && line2[i + 4].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i + 4].transform.position.x - 3.5f, line2[i + 4].transform.position.y, line2[i + 4].transform.position.z + 0.75f);
                    }
                    else if (i == 5 && line2[i - 5] != null && line2[i - 5].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i - 5].transform.position.x + 4.75f, line2[i - 5].transform.position.y, line2[i - 5].transform.position.z + 0.75f);
                    }
                    else if (i == 5 && line2[i - 4] != null && line2[i - 4].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i - 4].transform.position.x + 3.5f, line2[i - 4].transform.position.y, line2[i - 4].transform.position.z + 0.75f);
                    }
                    else if (i == 5 && line2[i - 3] != null && line2[i - 3].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i - 3].transform.position.x + 2.75f, line2[i - 3].transform.position.y, line2[i - 3].transform.position.z + 0.75f);
                    }
                    else if (i == 5 && line2[i - 2] != null && line2[i - 2].activeInHierarchy)
                    {
                        lines[i].transform.position = new Vector3(line2[i - 2].transform.position.x + 1.5f, line2[i - 2].transform.position.y, line2[i - 2].transform.position.z + 0.75f);
                    }
                    lines[i].SetActive(true);
                    active++;
                }
                deadLine = false;
            }

            if(prepared && active < 12)
            {
                deadLine = true;
            }
        }
    }

    IEnumerator Move()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            lines[lines.Count - i - 1].transform.position = new Vector3(lines[lines.Count - i - 1].transform.position.x + (dir * 0.07f), lines[lines.Count - i - 1].transform.position.y, lines[lines.Count - i - 1].transform.position.z - (0.04f));
            yield return new WaitForSecondsRealtime(0.01f);
        }
        if(back)
        {
            dir = dir * (-1);
            back = false;
            for (int i = 0; i < lines.Count; i++)
            {
                lines[lines.Count - i - 1].transform.position = new Vector3(lines[lines.Count - i - 1].transform.position.x, lines[lines.Count - i - 1].transform.position.y, lines[lines.Count - i - 1].transform.position.z - (0.2f));
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
        StartCoroutine("Move");
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSecondsRealtime(Random.Range(2, 5));
        actives[(int)Random.Range(0, 6)].GetComponent<Enemy>().Shoot();
        StartCoroutine("Shoot");
    }
}
