using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MetalSlug {
    public class ShotSpawn : MonoBehaviour
    {
        Quaternion directionUp = Quaternion.Euler(0f, 0f, 90f);
        Quaternion directionDown = Quaternion.Euler(0f, 0f, -90f);
        Quaternion directionZero = Quaternion.Euler(0f, 0f, 0f);

        PlayerBehaviour player;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }
        // Start is called before the first frame update
        void Start()
        {
            player = GetComponentInParent<PlayerBehaviour>();
        }

        // Update is called once per frame
        void Update()
        {
            if ((Input.GetAxisRaw("Vertical") > 0))
            {
                transform.rotation = directionUp;
            }
            else if (Input.GetAxisRaw("Vertical") < 0 && !player.Crouched)
            {
                transform.rotation = directionDown;
            }
            else
            {
                transform.rotation = transform.parent.rotation;
            }

            
        }

        private void LookUp()
        {

        }
    } 
}
