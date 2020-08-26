using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionMario : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            transform.Rotate(0,90,0);
        }
    }
}
