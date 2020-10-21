using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Controljugador : MonoBehaviour
{

    private Transform player;
    public float velocidad;
    public float maxBound, MinBound;

    public GameObject shot;
    public Transform spawnShot;
    public float fireRate;

    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x < MinBound && h < 0)
            h = 0;
        else if (player.position.x > maxBound && h > 0)
            h = 0;

        player.position += Vector3.right * h * velocidad;
    }
    //void Update()
    //{
    //    if (Input.GetButton("Fire1") && Time.time > nextFire
    //    {
    //        nextFire = Time.time + fireRate;
    //        Instantiate(shot, spawnShot.position, spawnShot.rotation);
    //    }
    //}
}
