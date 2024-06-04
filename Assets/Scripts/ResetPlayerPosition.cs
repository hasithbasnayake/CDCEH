using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class ResetPlayerPosition : MonoBehaviour
{
    private bool returnToMenu;
    private bool onlyOnceY;
    private bool onlyOnceX;
    private Vector3 menuPosition;
    private Vector3 playPosition;
    private registerDevices controllers;
    public GameObject leftHand;
    public GameObject rightHand;
    public Canvas menuCanvas;
    public Canvas controlsCanvas;
    public Canvas settingsCanvas;
    public Canvas instructionCanvas;
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject triangle1;
    public GameObject triangle2;
    public GameObject triangle3;
    private GameObject[] balls;
    private Vector3[] initialBallPositions;
    private Quaternion[] initialBallRotations;
    // Start is called before the first frame update
    void Start()
    {
        controllers = GetComponent<registerDevices>();
        menuPosition = new Vector3(-40, 0, 0);
        playPosition = new Vector3(0, 2, 0);
        returnToMenu = true;
        onlyOnceY = true;
        onlyOnceX = true;
        balls = new GameObject[6] {ball1, ball2, ball3, triangle1, triangle2, triangle3};
        initialBallPositions = new Vector3[6];
        initialBallRotations = new Quaternion[6];
        for (int i = 0; i < 6; i++) {
            initialBallPositions[i] = balls[i].transform.position;
            initialBallRotations[i] = balls[i].transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool Ybutton;
        bool Xbutton;
        if (controllers.leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out Ybutton) && Ybutton)
        {
            if (onlyOnceY) {
                onlyOnceY = false;
                changeLocations();
            }
        } else if (!Ybutton) {
            onlyOnceY = true;
        }
        if (controllers.leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out Xbutton) && Xbutton)
        {
            if (onlyOnceX) {
                onlyOnceX = false;
                resetBalls();
            }
        } else if (!Xbutton) {
            onlyOnceX = true;
        }
        if (transform.position.y < -3)
        {
            if (returnToMenu) {
                transform.position = menuPosition;
            } else {
                transform.position = playPosition;
            }
        }
    }

    void resetBalls() {
        for (int i = 0; i < 6; i++) {
            balls[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            balls[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            balls[i].transform.position = initialBallPositions[i];
            balls[i].transform.rotation = initialBallRotations[i];
        }
    }

    void changeLocations() {
        if (returnToMenu) {
            transform.position = playPosition;
            // transform.rotation = Quaternion.Euler(0, 180, 0);
            menuCanvas.enabled = false;
            controlsCanvas.enabled = false;
            settingsCanvas.enabled = false;
            instructionCanvas.enabled = true;
            leftHand.GetComponent<XRRayInteractor>().maxRaycastDistance = 0;
            rightHand.GetComponent<XRRayInteractor>().maxRaycastDistance = 0;
            returnToMenu = false;
        } else {
            transform.position = menuPosition;
            // transform.rotation = Quaternion.Euler(0, 270, 0);
            menuCanvas.enabled = true;
            instructionCanvas.enabled = false;
            leftHand.GetComponent<XRRayInteractor>().maxRaycastDistance = 300;
            rightHand.GetComponent<XRRayInteractor>().maxRaycastDistance = 300;
            returnToMenu = true;
        }
    }

    public void ViewControls() {
        menuCanvas.enabled = false;
        controlsCanvas.enabled = true;
    }

    public void ViewSettings() {
        menuCanvas.enabled = false;
        settingsCanvas.enabled = true;
    }
    public void ViewMenu() {
        menuCanvas.enabled = true;
        controlsCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }
}
