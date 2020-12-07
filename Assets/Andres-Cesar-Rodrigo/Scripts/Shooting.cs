using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab; //prefab de la flecha
    public float fireRate = 0.5f; //cadencia de tiro

    private bool canShoot; //condición de cadencia
    public Rigidbody2D rb;

    public AudioClip shoot;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            canShoot = false;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        StartCoroutine(Sound());
        StartCoroutine(ShootGun());
    }

    IEnumerator Sound()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = shoot;
    }
    IEnumerator ShootGun()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
