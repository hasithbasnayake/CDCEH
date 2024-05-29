using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Import the XR Interaction Toolkit namespace

public class grabQueue : MonoBehaviour
{
    public AudioSource grabSound;   // Sound to play when the object is grabbed
    public AudioSource impactSound; // Sound to play when the object hits the ground
    private XRGrabInteractable grabInteractable; // Reference to the XRGrabInteractable component

    void Awake()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            // Optionally add the XRGrabInteractable component if it's not already attached
            grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        }

        // Subscribe to the onSelectEntered event which is triggered when the object is grabbed
        grabInteractable.onSelectEntered.AddListener(PlayGrabSound);
    }

    private void PlayGrabSound(XRBaseInteractor interactor)
    {
        // Play the grab sound
        grabSound.Play();
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        grabInteractable.onSelectEntered.RemoveListener(PlayGrabSound);
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
