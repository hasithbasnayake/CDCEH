using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
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
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        initialPosition = this.gameObject.transform.position;
        initialRotation = this.gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < -3 || this.gameObject.transform.position.y > 10 || this.gameObject.transform.position.x < -6 || this.gameObject.transform.position.x > 3.5 || this.gameObject.transform.position.z < -6.5 || this.gameObject.transform.position.z > 3.5)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.gameObject.transform.rotation = initialRotation;
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
