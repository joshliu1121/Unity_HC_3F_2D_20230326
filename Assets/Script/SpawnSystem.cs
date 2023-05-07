using UnityEngine;

namespace LSC
{
    public class SpawnSystem : MonoBehaviour
    {
        [Header("生成間隔"), Range(0, 10)]
        public float interval = 3.5f;

        [Header("生成怪物預置物")]
        public GameObject prefabEnemy;
    }
}
