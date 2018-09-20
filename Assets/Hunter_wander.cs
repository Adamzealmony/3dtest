using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Hunter_wander : MonoBehaviour {

    NavMeshAgent navMeshAgent;
    public float timerForNewPath;
    public int delay = 0;
    public string NewLevel = "Scene2";
    bool inCoroutine;
	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!inCoroutine)
        {
            if(delay <= 10)
            {
                StartCoroutine(Wander());
            }
            else
            {
                SceneManager.LoadScene(NewLevel);
            }           
        }
        
	}

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-6, 6);
        float z = Random.Range(-6, 6);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator Wander()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath();
        delay++;    
        inCoroutine = false;
    }

    void GetNewPath()
    {
        navMeshAgent.SetDestination(getNewRandomPosition());
    }
}
