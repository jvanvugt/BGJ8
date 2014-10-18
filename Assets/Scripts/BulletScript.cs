using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed = 10f;

	// Use this for initialization
	void Start () {
        rigidbody2D.velocity = transform.right * speed;
        transform.position = transform.position + transform.right * 0.5f;
        Destroy(gameObject, 3f);
	}
	
    void OnHitEnemy()
    {
        Destroy(gameObject,0.05f);
    }
}
