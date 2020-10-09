using UnityEngine;

namespace MetalSlug
{
    public class PlayerMovement : MonoBehaviour
    {

       
        [SerializeField] private float velocity;

        private Quaternion directionLeft;
        private Quaternion directionRight;

        private Rigidbody rb;

        public Quaternion lastDirection;

        private bool jumping;
        float timer = 0f;

        void Start()
        {
            rb = this.GetComponent<Rigidbody>();
            lastDirection = Quaternion.Euler(0f, 0f, 0f);

            directionLeft =  Quaternion.Euler(0f, 180f, 0f);
            directionRight = Quaternion.Euler(0f, 0f, 0f);
        }

        

        private void Update()
        {
            TakeInput();
            Jump();
            Move();
            
        }

        private Vector3 TakeInput()
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                
                return Vector3.zero;
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                lastDirection = directionLeft;
                return new Vector3(-1f, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                lastDirection = directionRight;
                return new Vector3(1f, 0f, 0f);
            }

            return Vector3.zero;
        }

        private void Move()
        {
            Vector3 _vector = TakeInput();

            transform.rotation = lastDirection;
            transform.position += velocity * _vector;
        }
         
        private void Jump()
        {
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
            }
            if (jumping == true && timer <= 0.25f)
            {
                timer += Time.deltaTime;
                transform.position += Vector3.up * velocity;
            }
            else
            {
                timer = 0f;
                jumping = false;
            }

            
        } 
        
    }
}
