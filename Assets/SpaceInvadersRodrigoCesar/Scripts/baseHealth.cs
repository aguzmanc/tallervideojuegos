using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class baseHealth : MonoBehaviour
{
    public float health = 2;

    void Update ()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
