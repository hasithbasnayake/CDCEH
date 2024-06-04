using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class instructionSteps : MonoBehaviour
{
    public int stepID;
    private bool onlyOnceA;
    private bool onlyOnceX;
    private registerDevices controllers;
    // Start is called before the first frame update
    void Start()
    {
        controllers = GetComponent<registerDevices>();
        onlyOnceX = true;
        onlyOnceA = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool Abutton;
        bool Xbutton;
        if (controllers.rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out Abutton) && Abutton)
        {
            if (onlyOnceA) {
                onlyOnceA = false;
                changeStepID(-1);
                // scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            }
        } else if (!Abutton) {
            onlyOnceA = true;
        }
        if (controllers.rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out Xbutton) && Xbutton)
        {
            if (onlyOnceX) {
                onlyOnceX = false;
                changeStepID(1);
                // scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            }
        } else if (!Xbutton) {
            onlyOnceX = true;
        }
    }
    void changeStepID(int num) {
        stepID += num;
        if (stepID < 0) { // can't go below 0, 0 is the lowest step number
            stepID = 0;
        }
        if (stepID > 10) { // can't go above 10, 10 is the highest step number
            stepID = 10;
        }
        changeText();
    }
    void changeText() {
        if (stepID == 0)
        {
            GetComponent<TMPro.TextMeshPro>().text = "Hello, I'm your A.I. assistant. I'll guide you through the instructions on learning to juggle. Remember to press A to advance to next instruction and B to go back an instruction step.";
        } else if (stepID == 1) {
            GetComponent<TMPro.TextMeshPro>().text = "1. Grab a red ball with your right hand.";
        } else if (stepID == 2) {
            GetComponent<TMPro.TextMeshPro>().text = "2. Toss the ball in the air with your right hand and catch with your left hand.";
        } else if (stepID == 3) {
            GetComponent<TMPro.TextMeshPro>().text = "3. Toss ball in the air with your left hand and catch with your right hand.";
        } else if (stepID == 4) {
            GetComponent<TMPro.TextMeshPro>().text = "4. Now grab a blue ball with your left hand so you have one ball in each hand.";
        } else if (stepID == 5) {
            GetComponent<TMPro.TextMeshPro>().text = "5. Now you are going to try juggling with two balls.";
        } else if (stepID == 6) {
            GetComponent<TMPro.TextMeshPro>().text = "6. To do this you will toss the red ball in the air with your right hand, then while it is in the air toss the blue ball in the air with your left hand. Then you will catch the balls in the opposite hand they were tossed from.";
        } else if (stepID == 7) {
            GetComponent<TMPro.TextMeshPro>().text = "7. Now repeat the previous step but start with tossing the ball in your left hand.";
        } else if (stepID == 8) {
            GetComponent<TMPro.TextMeshPro>().text = "8. Now we will practice adding in the third ball!";
        } else if (stepID == 9) {
            GetComponent<TMPro.TextMeshPro>().text = "9. Immediately after tossing the first ball, grab the final (yellow) ball from the table and then incorporate that into the same toss then catch motion we practiced earlier except now with three balls in the air instead of two.";
        } else if (stepID == 10) {
            GetComponent<TMPro.TextMeshPro>().text = "10. Once you have all three balls in the juggling motion going, just keep doing the same thing to juggle for longer.";
        }
    }
}