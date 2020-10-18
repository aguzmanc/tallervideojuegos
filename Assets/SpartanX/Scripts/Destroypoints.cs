using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroypoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0.02f, 0);
    }
}
