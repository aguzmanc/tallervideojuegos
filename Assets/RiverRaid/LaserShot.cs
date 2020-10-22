using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour {

//reference variable for Rigidbody2D
Rigidbody2D rb;
//variable for force power
public float force;
public float tiempovidalazer = 0;

//will be executed once
void Start () {
//reference to Rigidbody2D
rb = GetComponent < Rigidbody2D > ();
//declare Vector3 with force value on Y-axe
Vector3 directon = new Vector3 (0, force, 0);
//add force push on rigidbody2D for moving on Y-axe
rb.AddForce (directon, ForceMode2D.Impulse);
}
//will be executed, if the gameobject is not rendering anymore on the screen
void update()
 {
//delete this gameobject from the scene

        tiempovidalazer += Time.deltaTime;
        if (tiempovidalazer > 10) 
        {
            Destroy(this.gameObject);
        }
}
}
