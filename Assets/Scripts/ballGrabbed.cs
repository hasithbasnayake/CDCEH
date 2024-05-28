using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ballGrabbed : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public delegate void Grabbed();
    public static event Grabbed OnGrabbed;
    public delegate void Released();
    public static event Released OnReleased;
    private bool grabbed = false;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        initialPosition = this.gameObject.transform.position;
        // Time.timeScale = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < -3)
        {
            this.gameObject.transform.position = initialPosition;
        }
        if (grabInteractable.isSelected)
        {
            if (!grabbed) {
                Debug.Log("I'm being grabbed!");
                grabbed = true;
                if (OnGrabbed != null) {
                    OnGrabbed();
                }
            }
        } else {
            if (grabbed) {
                Debug.Log("I'm not being grabbed!");
                grabbed = false;
                if (OnReleased != null) {
                    OnReleased();
                }
            }
        }
    }
}
