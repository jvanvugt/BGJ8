using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameObject player;
    public float speed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Look at player
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
	}

    void FixedUpdate()
    {
        rigidbody2D.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Player" || other.tag == "Bullet")
        {
            Debug.Log("Hit");
            other.SendMessage("OnHitEnemy");
            Destroy(gameObject);
        }
    }
}
