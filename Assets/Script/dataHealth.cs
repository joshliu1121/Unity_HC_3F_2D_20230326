using UnityEngine;

namespace LSC
{
    [CreateAssetMenu(menuName = "LSC/dataHealth")]
    public class DataHealth : ScriptableObject
    {
        [Header("血量"), Range(1, 5000)]
        public float hp = 500;
    }
}

