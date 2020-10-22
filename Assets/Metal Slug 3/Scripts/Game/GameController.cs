using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalSlug
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField] private GameObject player;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Dead()
        {
            player.SetActive(false);
        }

        public void Respawn()
        {
            player.transform.position = new Vector3(player.transform.position.x - 1f,
                player.transform.position.y + 2f, 0f);
            player.SetActive(true);
        }
    }
}
