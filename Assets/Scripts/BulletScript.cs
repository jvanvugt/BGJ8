using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        rigidbody2D.velocity = transform.right * 10f;
        Destroy(gameObject, 1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    }
}
