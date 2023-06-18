using UnityEngine;

namespace LSC
{
    public class WeaponSystem : MonoBehaviour
    {
        [Header("生成間隔"), Range(0, 10)]
        public float interval = 1.5f;

        [Header("武器預置物")]
        public GameObject prefabWeapon;

        [Header("武器生成位置")]
        public Transform pointWeapon;

        private void SpwanWeapon()
        {
            Instantiate(prefabWeapon, transform.position, transform.rotation);
        }

        private void Awake()
        {
            InvokeRepeating("SpwanWeapon", 0, interval);
        }
    }
}

