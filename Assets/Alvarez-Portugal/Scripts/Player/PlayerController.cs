using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlvarezPortugal 
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private bool isMoving;

        [SerializeField] private Rigidbody2D rb;
       

        Vector2 movement;
        

        private SpriteRenderer spriteRenderer;

        private float timer;

        private void Start()
        {
            spriteRenderer = this.GetComponent<SpriteRenderer>();
            rb = this.GetComponent<Rigidbody2D>();
        }

        
        void Update()
        {
            

            //Input

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x == -1f)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

        }

        private void FixedUpdate()
        {
            //Movement

            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            
        }

       
    }
}