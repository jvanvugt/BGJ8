using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector2 speed = new Vector2(1, 1);
    public GameObject bullet;
    public int health = 100;

    private float rateOfFire = 0.25f;
    private float lastFired = 0f;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > lastFired + rateOfFire)
            {
                lastFired = Time.time;
                GameObject b = (GameObject) Instantiate(bullet);
                b.transform.position = transform.position;
                b.transform.rotation = transform.rotation;
            }
        }

        // Look at mouse
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - objectPos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * speed.x, 
                                        Input.GetAxisRaw("Vertical") * speed.y);
        rigidbody2D.MovePosition(rigidbody2D.position + moveDir * Time.deltaTime);
	}

    void OnHitEnemy()
    {
        health -= 1;
    }
}
