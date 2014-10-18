using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 3f;
    public GameObject bullet;
    public int currentHealth = 3;
    public int maxHealth = 3;
    public GameObject[] hearths = new GameObject[3];

    private float rateOfFire = 0.25f;
    private float lastFired = 0f;
    private Animator anim;
    private int idleHash = Animator.StringToHash("Idle");
    private int walkingHash = Animator.StringToHash("Walking");
    private float snappiness = 10f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            anim.Play(walkingHash);
        }
        else
        {
            anim.Play(idleHash);
        }
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
        if (currentHealth < 1)
        {
            Application.LoadLevel("gameover");
        }

        for(int i = maxHealth -1; i >= 0; i--)
        {
            hearths[i].SetActive(i+1 <= currentHealth);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 
                                        Input.GetAxisRaw("Vertical") * speed);

        rigidbody2D.velocity = Vector3.Lerp(rigidbody2D.velocity, moveDir, Time.deltaTime * snappiness);
	}

    void OnHitEnemy()
    {
        currentHealth -= 1;
    }
}
