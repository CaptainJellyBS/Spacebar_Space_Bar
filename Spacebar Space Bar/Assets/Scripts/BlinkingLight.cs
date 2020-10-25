using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public float onTime, offTime;
    public Color blinkColor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while(true)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            yield return new WaitForSeconds(offTime);

            GetComponent<Renderer>().material.SetColor("_EmissionColor", blinkColor);
            yield return new WaitForSeconds(onTime);
        }
    }
}
