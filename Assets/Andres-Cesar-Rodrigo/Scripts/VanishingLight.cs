using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingLight : MonoBehaviour
{
    public Light spotLight;

    public float rangeSpeed = 8f;
    public float maxRange = 179f;
    public float minRange = 30f;
    //private bool lighter = true;

    void Update()
    {
        if (spotLight.spotAngle != minRange)
        {
            spotLight.spotAngle = Mathf.Clamp(spotLight.spotAngle, minRange, maxRange - Time.time * rangeSpeed);
        }

        /*if (spotLight.spotAngle == minRange)
        {
            lighter = false;
        }

        switch(lighter)
        {
            case true:
                spotLight.spotAngle = Mathf.Clamp(spotLight.spotAngle, minRange ,maxRange - Time.time * rangeSpeed);
                break;

            case false:
                spotLight.spotAngle = 80f;
                break;

        }*/
    }
}
