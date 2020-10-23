using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MetalSlug
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Vector2 speedVector;
        [SerializeField] private Animator animator;
        
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private int hp;
        [SerializeField] private int damage;
        [SerializeField] private float cooldown;

        private float timer;

        [SerializeField] private float DetectDistance;
        [SerializeField] private float AttackDistance;

        [SerializeField] private float distanceToTarget;
        [SerializeField] private float distanceToTargetRaw;

        public float DistanceToWander;

        [SerializeField] protected Transform target;

        [SerializeField] protected Transform ancle1;
        [SerializeField] protected Transform ancle2;

        private EnemyState State;

        public void Instantiate(EnemyState state)
        {
            State = state;
        }

        public enum EnemyState
        {
            IDLE,
            WALKING_TO_PLAYER,
            ATTACKING

        }
        private void Awake()
        {
            animator = GetComponent<Animator>();
            target = FindObjectOfType<PlayerBehaviour>().transform;
            rb = GetComponent<Rigidbody2D>();

            State = EnemyState.IDLE;

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void GetToTarget()
        {
            if (distanceToTargetRaw < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (speed < 0)
                {
                    
                }
                else
                {
                    speed *= -1;
                }
            }
            else if (distanceToTargetRaw > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                if (speed > 0)
                {
                    
                }
                else
                {
                    speed *= -1;
                }
            }

            rb.velocity = new Vector2(speed, rb.velocity.y);


        }

        public void Attack()
        {

        }

        public void Wander()
        {

            rb.velocity = new Vector2(speed, rb.velocity.y);


            float ancle2Distance = Mathf.Abs(ancle2.position.x - transform.position.x);
            float ancle1Distance = Mathf.Abs(ancle1.position.x - transform.position.x);

            Debug.Log(ancle1Distance + "  " + ancle2Distance);
            

            if (ancle2Distance <  0.1)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                speed *= -1;
                transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
                
            }
            else if (ancle1Distance <  0.1)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                speed *= -1;
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);

            }






        }

        public void UpdateEnemy()
        {
            Debug.Log(State);
            distanceToTargetRaw = target.position.x - transform.position.x;
            distanceToTarget = Mathf.Abs(distanceToTargetRaw);
            switch (State)
            {
                case EnemyState.IDLE:
                    Wander();

                    if (distanceToTarget <= DetectDistance)
                    {
                        State = EnemyState.WALKING_TO_PLAYER;
                    }
                    break;
                case EnemyState.WALKING_TO_PLAYER:
                    
                    GetToTarget();
                    if (distanceToTarget <= AttackDistance)
                    {
                        State = EnemyState.ATTACKING;
                    }
                    break;
                case EnemyState.ATTACKING:
                    rb.velocity = new Vector2(0f, rb.velocity.y);
                    timer += Time.deltaTime;

                     
                    if (timer >= cooldown)
                    {
                        timer = 0f;
                        animator.SetTrigger("isAttacking");
                    }
                    if (distanceToTarget < AttackDistance)
                    {
                        return;
                    }
                    else
                    {
                        State = EnemyState.WALKING_TO_PLAYER;
                    }
                    
                    break;
                default:
                    break;
            }

            
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Bullet")
            {
                Destroy(this.gameObject);
            }
             
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Enemy")
            {
                speed *= -1;
            }
        }
    } 
}
