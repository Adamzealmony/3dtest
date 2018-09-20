using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class red_path : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    public GameObject[] objects;
    public float timerForNewPath;
    int index = 0;
    public string NewLevel = "Scene2";
    bool arrive = true;
    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arrive)
        {
            StartCoroutine(Wander(objects[index]));
            arrive = false;
            
            
        }
        
        if(Vector3.SqrMagnitude(this.transform.position - objects[index].transform.position) < 0.01)
        {
            arrive = true;
            if (index != objects.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

    }

    IEnumerator Wander(GameObject g)
    {
        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath(g);
    }

    void GetNewPath(GameObject g)
    {
        navMeshAgent.SetDestination(g.transform.position);
    }
}
