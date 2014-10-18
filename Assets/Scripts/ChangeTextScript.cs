using UnityEngine;
using System.Collections;

public class ChangeTextScript : MonoBehaviour {

    public int goal;

    private int current;

	// Use this for initialization
	void Start () {
        guiText.text = current + "/" + goal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnemyKilled()
    {
        guiText.text = ++current + "/" + goal;
        if (current == goal)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
