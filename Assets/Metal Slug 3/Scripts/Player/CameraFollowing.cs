using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float scaleFactor;
    [SerializeField] private float speedFollow;
    Camera myCam;

    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myCam.orthographicSize = (Screen.height / 100f) / scaleFactor;

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position,
                                    speedFollow) + new Vector3(0f, 0f, -10f);

        }
    }
}
