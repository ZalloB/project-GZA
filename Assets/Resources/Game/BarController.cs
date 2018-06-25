using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarController : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    public Image content;

    public float value;
    public float MaxValue = 100;

    public float lerpSpeed = 2;

    // Use this for initialization
    void Start () {
        value = 100;
	}
	
	// Update is called once per frame
	void Update () {
        handleBar();
	}

    private void handleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }

        //content.fillAmount = map(value, 0, MaxValue, 0, 1);
    }

    public void map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        // example (90 - 0) * (1 - 0) / (100 - 0) + 0 -- to pass 0 --100 to 0--1 to map with bar image
        fillAmount =  (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
