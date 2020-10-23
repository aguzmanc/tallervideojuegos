using System;
using UnityEditor.UIElements;
using UnityEngine;

namespace MetalSlug
{
    public class PlayerBehaviour : MonoBehaviour
    {
        

        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        public AudioSource audioSource;
        public Animator animatorLegs;
        public Animator animatorBody;
        public float Speed => speed;
        public float JumpForce => JumpForce;

        private bool facingRight = true, jump, onGround, isDead, crouched, lookingUp;
        [HideInInspector]
        public bool Jump => jump;
        [HideInInspector]
        public bool OnGround => onGround;
        [HideInInspector]
        public bool IsDead => isDead;
        [HideInInspector]
        public bool Crouched => crouched;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform bulletSpawner;
        [SerializeField] private GameObject bulletPrefab;
        private float hForce;

        [SerializeField] private float fireRate = 0.8f;
        private float nextFire;
        private bool shooting;

       Quaternion lastDirection, directionRight, directionLeft;

        private Rigidbody2D rb;

       

        private bool jumping;
        float timer = 0f;



        void Start()
        {
            rb = this.GetComponent<Rigidbody2D>();
            groundCheck = gameObject.transform.Find("groundCheck");

            
            
            lastDirection = Quaternion.Euler(0f, 0f, 0f);
            directionLeft =  Quaternion.Euler(0f, 180f, 0f);
            directionRight = Quaternion.Euler(0f, 0f, 0f);

            audioSource = GetComponent<AudioSource>();
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                GameController.Instance.Dead();
                
            }
        }

        private void Update()
        {
            if (!isDead)
            {
                onGround = Physics2D.Linecast(transform.position,
                            groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

                if (Input.GetKeyDown(KeyCode.Space) && onGround)
                {
                    jump = true;
                    animatorLegs.SetTrigger("isJumping");
                }

                if (!onGround)
                {
                    
                    animatorLegs.SetBool("isFalling", true);
                }
                else if (onGround)
                {
                    animatorLegs.SetBool("isFalling", false);
                }
               

                if (Input.GetKeyDown(KeyCode.Keypad7) && shooting == false)
                {
                    shooting = true;
                    
                    Instantiate(bulletPrefab, bulletSpawner.transform.position, bulletSpawner.rotation);
                    
                    
                }

                if (shooting == true)
                {
                    nextFire += Time.deltaTime;
                    if (nextFire >= fireRate)
                    {
                        shooting = false;
                        nextFire = 0;
                    }
                }
                

                if (Input.GetAxisRaw("Vertical") < 0 && onGround)
                {
                    crouched = true;
                }
                else
                {
                    crouched = false;
                }
               

            }

            
            
        }

        private void FixedUpdate()
        {
            if (!isDead)
            {
                hForce = Input.GetAxisRaw("Horizontal");

                rb.velocity = new Vector2(hForce * speed, rb.velocity.y);
                animatorLegs.SetBool("isWalking", true);
                animatorBody.SetBool("isWalking", true);

                if (hForce > 0)
                {
                    transform.rotation = directionRight;
                }
                else if (hForce < 0)
                {
                    transform.rotation = directionLeft;
                }

                if (hForce == 0)
                {
                    animatorLegs.SetBool("isWalking", false);
                    animatorBody.SetBool("isWalking", false);
                }

                if (jump)
                {
                    jump = false;
                    rb.AddForce(Vector2.up * jumpForce);
                }
            }
        }

    

        

        
        
    }
}
