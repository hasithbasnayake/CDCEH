using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.UI;


public class instructionStepsNew : MonoBehaviour
{
    public int stepID;
    public TMPro.TextMeshProUGUI instruction;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject image8;
    public GameObject image9;
    public GameObject image10;
    public GameObject image11;
    public GameObject image12;
    public GameObject image13;
    public GameObject image14;
    private bool onlyOnceA;
    private bool onlyOnceX;
    private bool onlyOnceY;
    private bool allowStepChange;
    private registerDevices controllers;
    void Start()
    {
        controllers = GetComponent<registerDevices>();
        onlyOnceX = true;
        onlyOnceA = true;
        onlyOnceY = true;
        allowStepChange = false;
    }

    void Update()
    {
        bool Abutton;
        bool Xbutton;
        bool Ybutton;
        if (controllers.rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out Abutton) && Abutton)
        {
            if (onlyOnceA) {
                onlyOnceA = false;
                changeStepID(-1);
            }
        } else if (!Abutton) {
            onlyOnceA = true;
        }
        if (controllers.rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out Xbutton) && Xbutton)
        {
            if (onlyOnceX) {
                onlyOnceX = false;
                changeStepID(1);
            }
        } else if (!Xbutton) {
            onlyOnceX = true;
        }
        if (controllers.leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out Ybutton) && Ybutton)
        {
            if (onlyOnceY) {
                onlyOnceY = false;
                allowStepChange = !allowStepChange;
            }
        } else if (!Ybutton) {
            onlyOnceY = true;
        }
    }
    void changeStepID(int num) {
        if (!allowStepChange) {
            return;
        }
        stepID += num;
        if (stepID < 0) { // can't go below 0, 0 is the lowest step number
            stepID = 0;
        }
        if (stepID > 14) { // can't go above 14, 14 is the highest step number
            stepID = 14;
        }
        changeTextAndImage();
    }
    void changeTextAndImage() {
        if (stepID == 0) {
            instruction.text = "Hello, I'm your A.I. assistant. I'll guide you through the instructions on learning to juggle. Remember to press A to advance to next instruction and B to go back an instruction step.";
            image1.SetActive(false);
        } else if (stepID == 1) {
            instruction.text = "1. Start with the yellow ball in your right hand, standing with your elbows bent 90 degrees and your palms facing up.";
            image1.SetActive(true);
            image2.SetActive(false);
        } else if (stepID == 2) {
            instruction.text = "2. Toss the ball to the other hand with an upward movement of the forearm. The peak of the throw trajectory should be slightly higher than eye level, and the angle of the throw should be so that the ball lands where your left hand is waiting.";
            image1.SetActive(false);
            image2.SetActive(true);
            image3.SetActive(false);
        } else if (stepID == 3) {
            instruction.text = "3. For catching we want to wait for the ball to reach our hand. If the ball will not exactly hit your hand, feel free to adjust yourself to catch it properly. Keep trying the last two steps until you can do it comfortably.";
            image2.SetActive(false);
            image3.SetActive(true);
            image4.SetActive(false);
        } else if (stepID == 4) {
            instruction.text = "4. Congratulations on learning how to do the basic throw. Now that you've learned this skill, we'll move onto the exchange. Place the yellow ball back into your right hand and grab the orange ball with your left hand.";
            image3.SetActive(false);
            image4.SetActive(true);
            image5.SetActive(false);
        } else if (stepID == 5) {
            instruction.text = "5. Throw the yellow ball from your right hand just like in Step 1.";
            image4.SetActive(false);
            image5.SetActive(true);
            image6.SetActive(false);
        } else if (stepID == 6) {
            instruction.text = "6. Once the ball is at the peak of its trajectory, throw the orange ball from your left hand \"underneath\" the yellow one (jugglers call this the inverse throw). Essentially, throw it in a manner that will avoid a collision between the two balls.";
            image5.SetActive(false);
            image6.SetActive(true);
            image7.SetActive(false);
        } else if (stepID == 7) {
            instruction.text = "7. Catch the yellow ball with your left hand and proceed to catch the orange ball with your right hand.";
            image6.SetActive(false);
            image7.SetActive(true);
            image8.SetActive(false);
        } else if (stepID == 8) {
            instruction.text = "8. Congratulations on learning the exchange! Try doing the exchange the opposite way (left to right) by repeating the previous steps but changing the order of the hands. If you can do the exchange on both sides, we can now move onto the cascade.";
            image7.SetActive(false);
            image8.SetActive(true);
            image9.SetActive(false);
        } else if (stepID == 9) {
            instruction.text = "9. Now we move onto the cascade, time for real juggling! Take three balls, two in your right hand, one in your left hand. However, we cannot hold two balls at once, so have the third ball (red) ready on the table by the right hand.";
            image8.SetActive(false);
            image9.SetActive(true);
            image10.SetActive(false);
        } else if (stepID == 10) {
            instruction.text = "10. Toss the yellow ball from your right hand and pick up the red ball from the table.";
            image9.SetActive(false);
            image10.SetActive(true);
            image11.SetActive(false);
        } else if (stepID == 11) {
            instruction.text = "11. Now we essentially preform the exchange, toss the orange ball from your left hand when the yellow ball is at about its peak.";
            image10.SetActive(false);
            image11.SetActive(true);
            image12.SetActive(false);
        } else if (stepID == 12) {
            instruction.text = "12. Catch the yellow ball with your left hand.";
            image11.SetActive(false);
            image12.SetActive(true);
            image13.SetActive(false);
        } else if (stepID == 13) {
            instruction.text = "13. When the orange ball is around its peak in its trajectory, throw the red ball from your right hand. This is where practicing the exchange going the opposite (left to right) way comes in handy.";
            image12.SetActive(false);
            image13.SetActive(true);
            image14.SetActive(false);
        } else if (stepID == 14) {
            instruction.text = "14. Catch the orange ball in your right hand. Now all you need to do is continue the same pattern of throwing and catching the balls. Congratulations, you are now juggling!";
            image13.SetActive(false);
            image14.SetActive(true);
        }
    }
}
