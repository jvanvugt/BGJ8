using UnityEngine;
using System.Collections;

public class ProgressScript : MonoBehaviour {

    public float secondPerProcent = 1f;
    public GameObject spawner;

    private int progress = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(IncreaseProgress());
        spawner.SetActive(false);
	}

    void OnEnable()
    {
        StartCoroutine(IncreaseProgress());
    }
	
	// Update is called once per frame
	void Update () {
        guiText.text = "scanning... " + progress + "%";
        if (progress >= 50)
        {
            spawner.SetActive(true);
        }
        if (progress >= 100)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
	}

    IEnumerator IncreaseProgress()
    {
        while (true) { 
            progress++;
            yield return new WaitForSeconds(secondPerProcent);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            progress -= 10;
            if (progress < 0)
                progress = 0;
            Destroy(other.gameObject);
        }
    }
}
