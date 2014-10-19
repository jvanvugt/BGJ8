using UnityEngine;
using System.Collections;

public class HearthScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("OnHearthPickup");
            particleSystem.Play();
            audio.Play();
            renderer.enabled = false;
            Destroy(gameObject, 1f);
            Destroy(this);
        }
    }
}
