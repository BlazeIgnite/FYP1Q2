using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public GameObject rock;
    float spawnInterval = 3f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnInterval, spawnInterval);
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void Spawn()
    {
        Instantiate(rock, this.transform.position, this.transform.rotation);
    }
}
