using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefabToSpawn;
    public float spawnInterval;

    void Start () {
        StartCoroutine(spawn());
    }
    
    void Update()
    {

    }

    private IEnumerator spawn()
    {
        Transform transform = this.GetComponent<Transform>();
        while (true)
        {
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
