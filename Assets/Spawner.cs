using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] objects;
    public Vector3 spawnValues;
    public int startWait;

	// Use this for initialization
	void Start () {
        StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator waitSpawner()
    {
        

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

        Instantiate(objects[0], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

        spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

        yield return new WaitForSeconds(startWait);

        Instantiate(objects[1], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    }
}
