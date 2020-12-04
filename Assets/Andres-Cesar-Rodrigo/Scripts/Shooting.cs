using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab; //prefab de la flecha
    public float fireRate = 0.5f; //cadencia de tiro

    public float arrowForce = 20f; //fuerza con la que es disparada la flecha
    private bool canShoot; //condición de cadencia

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
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        StartCoroutine(ShootGun());
    }

    IEnumerator ShootGun()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
