using MetalSlug;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalSlug
{
    public class SpawnEnemies : MonoBehaviour
    {
        public float timer;
        public float spawnRate;
        public int numberOfTimes;
        public GameObject enemyPrefab;

        private int numberOfTimerCount;
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("RespawnEnemies", timer, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {
            if (numberOfTimerCount >= numberOfTimes)
            {
                CancelInvoke();
            }
        }

        public void RespawnEnemies()
        {
            GreenCrab temp;
            temp = Instantiate(enemyPrefab, transform.position, transform.rotation).GetComponent<GreenCrab>();
            temp.Instantiate(Enemy.EnemyState.WALKING_TO_PLAYER);
            numberOfTimerCount += 1;

        }
    }
}
