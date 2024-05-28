using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabQueue : MonoBehaviour
{
    public AudioSource grabSound;   // Sound to play when the object is grabbed
    public AudioSource impactSound; // Sound to play when the object hits the ground

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            grabSound.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object hits the ground
        if (collision.gameObject.tag == "Ground")
        {
            impactSound.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
