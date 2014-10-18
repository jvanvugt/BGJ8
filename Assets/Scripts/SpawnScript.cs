using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject spawn;
    public float spawnTimer = 5f;
    public GameObject player;

    private float lastSpawned;

	// Use this for initialization
	void Start () {
        spawn.GetComponent<EnemyScript>().player = player;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > lastSpawned + spawnTimer)
        {
            lastSpawned = Time.time;
            Instantiate(spawn, transform.position, transform.rotation);
        }
	}
}
