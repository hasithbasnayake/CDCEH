using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateScore : MonoBehaviour
{
    // This script should be attached to our scoreboard text object
    private bool grabbed = false;
    public bool gameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Idea: have a button on the controller start the "game"
        // Score and audio cues will only start to update/happen when the "game" is started
        // "game": the player juggling
        if (gameStart) {
            if (!grabbed) {
                ballGrabbed.OnGrabbed += UpdateScore;
            } else {
                ballGrabbed.OnReleased += UpdateGrabbed;
            }
        }
    }

    void UpdateScore() {
        GetComponent<TMPro.TextMeshPro>().text = GetComponent<TMPro.TextMeshPro>().text + 1;
        grabbed = true;
    }
    void UpdateGrabbed() {
        grabbed = false;
    }
}
