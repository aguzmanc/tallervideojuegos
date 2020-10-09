using MetalSlug;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunController : MonoBehaviour
{
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponentInParent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
       //Idle
        transform.rotation = player.lastDirection;
        
        //LookUp
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        

       

    }
}
