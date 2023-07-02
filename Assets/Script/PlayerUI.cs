using UnityEngine;

namespace LSC
{
    public class PlayerUI : MonoBehaviour
    {
        private Transform player;
        private void Awake()
        {
            player = GameObject.Find("蘑菇").transform;
        }

        private void Update()
        {
            transform.position = player.position;
        }
    }

}