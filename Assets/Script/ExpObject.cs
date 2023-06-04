using System;
using UnityEngine;


namespace LSC
{
    public class ExpObject : MonoBehaviour
    {
        [Header("可以吃這個物件的名稱")]
        public string nameTarget = "蘑菇";
        [Header("移動速度"), Range(0, 500)]
        public float moveSpeed = 3.5f;
        private bool PlayerInArea;
        [Header("玩家吃掉物件的距離"), Range(0, 5)]
        public float eatDistance = 0.5f;
        [Header("經驗值"), Range(0, 5000)]
        public float exp = 30;

        private Transform player;

        private LevelManager levelManager;


        private void Awake()
        {
            player = GameObject.Find(nameTarget).transform;

            levelManager = FindObjectOfType<LevelManager>();
        }


        private void Update()
        {
            //如果 玩家進入範圍 為勾選狀態 就追蹤
            if (PlayerInArea)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                float distance = Vector2.Distance(transform.position, player.position);

                if (distance < eatDistance)
                {
                    levelManager.GetExp(exp);
                    Destroy(gameObject);
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            //print($"<color=#ff6699>{collision.name}</color>");


            //如果 (碰撞物件的名稱 包含(犀牛))
            if (collision.name.Contains(nameTarget))
            {
                //玩家進入範圍 = 勾選
                PlayerInArea = true;
            }
        }
    }
}
