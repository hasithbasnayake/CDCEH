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
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
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
