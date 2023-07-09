using UnityEngine;

namespace LSC
{
    public class SpawnSystem : MonoBehaviour
    {
        #region 資料
        [Header("生成間隔"), Range(0, 10)]
        public float interval = 3.5f;

        [Header("生成怪物預置物")]
        public GameObject prefabEnemy; 
        #endregion

        private void Awake()
        {
            InvokeRepeating("SpawnEnemy", 0, interval);
        }

        private void SpawnEnemy()
        {

            //生成物件的方法(要生成的物件  , 腳本物件座標 , 腳本物件角度);
            Instantiate(prefabEnemy, transform.position, transform.rotation);

        }
    }
}
