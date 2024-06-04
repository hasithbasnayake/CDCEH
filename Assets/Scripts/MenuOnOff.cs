using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class MenuOnOff : MonoBehaviour
{
    private registerDevices controllers;
    // Start is called before the first frame update
    void Start()
    {
        controllers = GetComponent<registerDevices>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controllers.leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool Xbutton) && Xbutton)
        {
            GetComponent<Canvas>().enabled = false;
        }
        if (controllers.leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool Ybutton) && Ybutton)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }
}
