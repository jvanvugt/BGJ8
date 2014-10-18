using UnityEngine;
using System.Collections;

public class TextScreenScript : MonoBehaviour {

    private GameObject[] texts;

	// Use this for initialization
	void Start () {
        texts = GameObject.FindGameObjectsWithTag("Text");
        foreach (GameObject text in texts)
        {
            text.SetActive(false);
        }
        Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
            foreach (GameObject text in texts)
            {
                text.SetActive(true);
            }
            Destroy(gameObject);
        }
	}
}
