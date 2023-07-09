using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

namespace LSC
{
    public class EnemySystem : MonoBehaviour
    {
        /// <summary>
        /// 敵人系統
        /// 1.追蹤玩家
        /// 2.翻面
        /// </summary>

        #region 資料
        [Header("追蹤速度")]
        public float moveSpeed = 2.5f;
        [Header("敵人資料")]
        public DataHealthEnemy data;

        private Transform player;
        private float timer;
        private DamagePlayer damagePlayer;


        #endregion

        //繪製敵人攻擊範圍
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 0.5f, 0.8f, 0.5f);
            Gizmos.DrawSphere(transform.position, data.attackRange);
        }

        private void Awake()
        {
            //搜尋遊戲物件並獲得變形資訊(座標、角度、大小等)
            //GameObject.Find("想要找到且在場景上的物件名稱").transform;
            player = GameObject.Find("蘑菇").transform;
            damagePlayer = player.GetComponent<DamagePlayer>();
        }

        private void Update()
        {
            //讓 A 座標往 B 座標移動
            //A座標 = 三維向量(A座標 , 玩家座標 , 移動速度*裝置每幀數花費的時間)
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < data.attackRange) Attack();
            if (transform.position.x > player.position.x) transform.eulerAngles = new Vector3(0, 0, 0);
            if (transform.position.x < player.position.x) transform.eulerAngles = new Vector3(0, 180, 0);




        }

        private void Attack()
        {
            //攻擊用計時器並測試
            timer += Time.deltaTime;

            //攻擊測試
            if (timer > data.attackInterval)
            {
                print("<color=#9966ff>攻擊玩家!!!</color>");
                timer = 0;
                damagePlayer.GetDamage(data.attack);
            }



        }


    }
}

