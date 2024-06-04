using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class timeAdjuster : MonoBehaviour
{
    private float sliderValue;
    public GameObject slider;
    public float originalVelocityThrow;
 
    private float timeOnStart;
 
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
 
    public TMPro.TextMeshProUGUI textValue;
 
    // Start is called before the first frame update
    void Start()
    {
        timeOnStart = Time.timeScale;
    }
 
    void Update()
    {
        sliderValue = slider.GetComponent<Slider>().value;
        textValue.text = sliderValue.ToString("#.00");
        //Time.timeScale = Time.timeScale * sliderValue;
        Time.timeScale = timeOnStart * sliderValue;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
 
        ball1.GetComponent<XRGrabVelocityTracked>().throwVelocityScale = originalVelocityThrow * sliderValue;
        ball2.GetComponent<XRGrabVelocityTracked>().throwVelocityScale = originalVelocityThrow * sliderValue;
        ball3.GetComponent<XRGrabVelocityTracked>().throwVelocityScale = originalVelocityThrow * sliderValue;
    }
}
