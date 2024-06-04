using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class updateScore : MonoBehaviour
{
    // This script should be attached to our scoreboard text object
    private bool grabbed = false;
    
    // Idea: have a button on the controller start the "game"
    // Score and audio cues will only start to update/happen when the "game" is started
    // "game": the player juggling
    public bool gameStart = true;
    private registerDevices controllers;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshPro>().text = "0";
        controllers = GetComponent<registerDevices>();
    }

    void OnEnable() {
        ballGrabbed.OnGrabbed += UpdateScore;
        ballGrabbed.OnReleased += UpdateGrabbed;
    }

    // Update is called once per frame
    void Update()
    {
        if (controllers.rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool Bbutton) && Bbutton)
        {
            GetComponent<TMPro.TextMeshPro>().text = "0";
        }
    }

    void UpdateScore() {
        GetComponent<TMPro.TextMeshPro>().text = (int.Parse(GetComponent<TMPro.TextMeshPro>().text) + 1).ToString();
        grabbed = true;
    }
    void UpdateGrabbed() {
        // GetComponent<TMPro.TextMeshPro>().text = "released";
        grabbed = false;
    }
}
