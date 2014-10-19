using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameObject player;
    public float speed = 3f;
    public GameObject hearth;

    private GameObject text;
    private float yScale;

	// Use this for initialization
	void Start () {
        text = GameObject.FindGameObjectsWithTag("Text")[0];
        yScale = transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
        // Look at player
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                                -yScale, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                                yScale, transform.localScale.z);
        }
	}

    void FixedUpdate()
    {
        rigidbody2D.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Bullet")
        {
            other.SendMessage("OnHitEnemy");
            if (other.tag == "Bullet")
            {
                audio.Play();
                if(text.name != "ProgressText")
                    text.SendMessage("OnEnemyKilled");
                if(Random.Range(0,15) == 5)
                    Instantiate(hearth, transform.position, Quaternion.identity);
            }
            particleSystem.Play();
            renderer.enabled = false;
            collider2D.enabled = false;
            Destroy(gameObject, 0.3f);
        }
    }
}
