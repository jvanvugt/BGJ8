using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed = 10f;

	// Use this for initialization
	void Start () {
        rigidbody2D.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
	}
	
    void OnHitEnemy()
    {
        Destroy(gameObject);
    }
}
