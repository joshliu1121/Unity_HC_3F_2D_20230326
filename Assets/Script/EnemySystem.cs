using UnityEngine;

namespace LSC
{
    public class EnemySystem : MonoBehaviour
    {
        /// <summary>
        /// 敵人系統
        /// 1.追蹤玩家
        /// 2.翻面
        /// </summary>
        
        #region 宣告
        [Header("追蹤速度")]
        public float moveSpeed = 2.5f;
        [Header("敵人資料")]
        public Transform player;

            #endregion

       
        
        private void Awake()
        {
            //搜尋遊戲物件並獲得變形資訊(座標、角度、大小等)
            //GameObject.Find("想要找到且在場景上的物件名稱").transform;
            player = GameObject.Find("蘑菇").transform;
        }

        private void Update()
        {
           //讓 A 座標往 B 座標移動
           //A座標 = 三維向量(A座標 , 玩家座標 , 移動速度*裝置每幀數花費的時間)
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed*Time.deltaTime);
        }
    }
}

